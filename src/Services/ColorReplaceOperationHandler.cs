using FlowSynx.Plugins.Media.ImageProcessing.Helpers;
using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services
{
    internal class ColorReplaceOperationHandler : IImageOperationHandler
    {
        public void Handle(Image image, InputParameter parameter)
        {
            if (string.IsNullOrEmpty(parameter.FromColor) || string.IsNullOrEmpty(parameter.ToColor))
                throw new ArgumentException("FromColor and ToColor are required.");

            var fromColor = ColorHelper.ParseToRgba32(parameter.FromColor);
            var toColor = ColorHelper.ParseToRgba32(parameter.ToColor);

            // Convert to RGBA32 for pixel-level access
            image.Mutate(ctx =>
            {
                // Use CloneAs<Rgba32> to get pixel access, then mutate in-place
                var imgRgba32 = image as Image<Rgba32> ?? image.CloneAs<Rgba32>();
                imgRgba32.ProcessPixelRows(accessor =>
                {
                    for (int y = 0; y < accessor.Height; y++)
                    {
                        var pixelRow = accessor.GetRowSpan(y);
                        for (int x = 0; x < pixelRow.Length; x++)
                        {
                            if (pixelRow[x].Equals(fromColor))
                                pixelRow[x] = toColor;
                        }
                    }
                });

                // If we cloned, copy the result back
                if (!ReferenceEquals(imgRgba32, image))
                {
                    image.Dispose();
                    image = imgRgba32;
                }
            });
        }
    }
}
