using FlowSynx.PluginCore;
using FlowSynx.PluginCore.Extensions;
using FlowSynx.Plugins.Media.ImageProcessing.Models;
using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

namespace FlowSynx.Plugins.Media.ImageProcessing;

public class ImageProcessingPlugin : IPlugin
{
    private readonly IGuidProvider _guidProvider;
    private readonly IReflectionGuard _reflectionGuard;
    private IPluginLogger? _logger;
    private bool _isInitialized;

    public ImageProcessingPlugin() : this(new GuidProvider(), new DefaultReflectionGuard()) { }

    internal ImageProcessingPlugin(IGuidProvider guidProvider, IReflectionGuard reflectionGuard)
    {
        _guidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
        _reflectionGuard = reflectionGuard ?? throw new ArgumentNullException(nameof(reflectionGuard));
    }

    public PluginMetadata Metadata => new PluginMetadata
    {
        Id = Guid.Parse("6ca63d18-28ba-4fd7-8564-4cc788101bd3"),
        Name = "ImageProcessing",
        CompanyName = "FlowSynx",
        Description = "Performs image processing operations like resize, rotate, grayscale, crop, etc.",
        Version = new Version(1, 0, 0),
        Category = PluginCategory.Media,
        Authors = new List<string> { "FlowSynx" },
        Copyright = "© FlowSynx",
        Icon = "flowsynx.png",
        ReadMe = "README.md",
        RepositoryUrl = "https://github.com/flowsynx/plugin-media-imageprocessing",
        ProjectUrl = "https://flowsynx.io",
        Tags = new List<string>() { "flowSynx", "image", "processing", "media", "graphics" },
        MinimumFlowSynxVersion = new Version(1, 1, 1),
    };

    public PluginSpecifications? Specifications { get; set; }

    public Type SpecificationsType => typeof(ImageProcessingPluginSpecifications);

    private Dictionary<string, IImageOperationHandler> OperationMap => new(StringComparer.OrdinalIgnoreCase)
    {
        ["resize"] = new ResizeOperationHandler(),
        ["rotate"] = new RotateOperationHandler(),
        ["grayscale"] = new GrayscaleOperationHandler(),
        ["sepia"] = new SepiaOperationHandler(),
        ["crop"] = new CropOperationHandler(),
        ["blur"] = new BlurOperationHandler(),
        ["sharpen"] = new SharpenOperationHandler(),
        ["brightness"] = new BrightnessOperationHandler(),
        ["contrast"] = new ContrastOperationHandler(),
        ["flip"] = new FlipOperationHandler(),
        ["watermark"] = new WatermarkOperationHandler(),
        ["colorreplace"] = new ColorReplaceOperationHandler(),
        ["edgedetect"] = new EdgeDetectionOperationHandler()
    };

    public IReadOnlyCollection<string> SupportedOperations => OperationMap.Keys;

    public Task Initialize(IPluginLogger logger)
    {
        EnsureNotReflection();
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
        _isInitialized = true;
        return Task.CompletedTask;
    }

    public async Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        EnsureNotReflection();
        EnsureInitialized();

        var inputParameter = parameters.ToObject<InputParameter>();
        if (!OperationMap.TryGetValue(inputParameter.Operation, out var handler))
        {
            throw new NotSupportedException($"Operation '{inputParameter.Operation}' is not supported.");
        }

        // Load image from PluginContext (base64 or raw bytes)
        var context = ParseDataToContext(inputParameter.Data);
        using var image = await LoadImageAsync(context, cancellationToken);

        // Apply image operation
        handler.Handle(image, inputParameter);

        // Save processed image as PNG
        using var ms = new MemoryStream();
        await image.SaveAsync(ms, new PngEncoder());
        var resultBytes = ms.ToArray();
        var base64 = Convert.ToBase64String(resultBytes);

        var result = new PluginContext($"{_guidProvider.NewGuid()}.png", "Media")
        {
            Format = "PNG",
            Content = base64,
            RawData = resultBytes
        };

        result.Metadata.Add("Width", image.Width);
        result.Metadata.Add("Height", image.Height);
        result.Metadata.Add("Format", "PNG");

        return result;
    }

    #region private methods
    private void EnsureNotReflection()
    {
        if (_reflectionGuard.IsCalledViaReflection())
            throw new InvalidOperationException(Resources.ReflectionBasedAccessIsNotAllowed);
    }

    private void EnsureInitialized()
    {
        if (!_isInitialized)
            throw new InvalidOperationException($"Plugin '{Metadata.Name}' v{Metadata.Version} is not initialized.");
    }

    private PluginContext ParseDataToContext(object? data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data), "Input data cannot be null.");

        return data switch
        {
            PluginContext singleContext => singleContext,
            IEnumerable<PluginContext> => throw new NotSupportedException("List of PluginContext is not supported."),
            string base64 => new PluginContext(_guidProvider.NewGuid().ToString(), "Media") { Content = base64 },
            byte[] bytes => new PluginContext(_guidProvider.NewGuid().ToString(), "Media") { Content = Convert.ToBase64String(bytes) },
            _ => throw new NotSupportedException("Unsupported input data format.")
        };
    }

    private static async Task<Image> LoadImageAsync(PluginContext context, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(context);

        byte[] bytes = context.RawData
            ?? (context.Content is not null
                ? Convert.FromBase64String(context.Content)
                : throw new InvalidDataException($"Image content is missing in PluginContext {context.Id}."));

        await using var ms = new MemoryStream(bytes, writable: false);
        return await Image.LoadAsync(ms, cancellationToken).ConfigureAwait(false);
    }
    #endregion
}