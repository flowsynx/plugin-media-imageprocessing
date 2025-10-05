## Image Processing Plugin

The **Image Processing Plugin** is a built-in, plug-and-play integration for the FlowSynx automation engine. It enables performing common image processing operations (resize, rotate, grayscale, crop, etc.) within workflows, with no custom coding required.

This plugin is automatically installed by the FlowSynx engine when selected in the workflow builder. It is not intended for standalone developer usage outside the FlowSynx platform.

---

## Purpose

The Image Processing Plugin allows FlowSynx users to:

- Resize images to specific dimensions.
- Rotate images by a given angle.
- Convert images to grayscale or sepia.
- Crop images to a specified region.
- Apply blur or sharpen effects.
- Adjust brightness and contrast.
- Flip images horizontally or vertically.
- Add watermarks to images.
- Replace specific colors in images.
- Detect edges in images.

It integrates seamlessly into FlowSynx no-code/low-code workflows for media processing and transformation tasks.

---

## Supported Operations

- **resize**: Resize the image to the specified width and height.
- **rotate**: Rotate the image by a given angle (degrees).
- **grayscale**: Convert the image to grayscale.
- **sepia**: Apply a sepia tone to the image.
- **crop**: Crop the image to the specified width and height.
- **blur**: Apply a blur effect with a given radius.
- **sharpen**: Sharpen the image with a given radius.
- **brightness**: Adjust the image brightness by a specified amount.
- **contrast**: Adjust the image contrast by a specified amount.
- **flip**: Flip the image horizontally or vertically.
- **watermark**: Add a text watermark to the image.
- **colorreplace**: Replace a specific color in the image with another color.
- **edgedetect**: Detect edges in the image.

---

## Input Parameters

The plugin accepts the following parameters:

- `Operation` (string): **Required.** The type of operation to perform. Supported values are listed above.
- `Data` (string or byte[]): **Required.** The image data as a base64 string or raw bytes.
- Operation-specific parameters (optional):
  - `Width` (int): For `resize`/`crop` operations.
  - `Height` (int): For `resize`/`crop` operations.
  - `Angle` (float): For `rotate` operation.
  - `Radius` (float): For `blur`/`sharpen` operations.
  - `Amount` (float): For `brightness`/`contrast` operations.
  - `FlipMode` (string): For `flip` operation (`horizontal` or `vertical`).
  - `WatermarkText` (string): For `watermark` operation (text to overlay).
  - `FromColor` (string): For `colorreplace` operation (color to replace, as a string, e.g., "#FF0000FF" or "rgba(255,0,0,255)").
  - `ToColor` (string): For `colorreplace` operation (replacement color, same format as above).

### Example input (resize)

```json
{
  "Operation": "resize",
  "Data": "<base64-image>",
  "Width": 200,
  "Height": 100
}
```

### Example input (watermark)

```json
{
  "Operation": "watermark",
  "Data": "<base64-image>",
  "WatermarkText": "Sample watermark"
}
```

### Example input (colorreplace)

```json
{
  "Operation": "colorreplace",
  "Data": "<base64-image>",
  "FromColor": "255,0,0,255",
  "ToColor": "0,0,255,255"
}
```

---

## Operation Examples

### resize Operation

**Input Parameters:**

```json
{
  "Operation": "resize",
  "Data": "<base64-image>",
  "Width": 200,
  "Height": 100
}
```

---

### rotate Operation

**Input Parameters:**

```json
{
  "Operation": "rotate",
  "Data": "<base64-image>",
  "Angle": 90
}
```

---

### grayscale Operation

**Input Parameters:**

```json
{
  "Operation": "grayscale",
  "Data": "<base64-image>"
}
```

---

### watermark Operation

**Input Parameters:**

```json
{
  "Operation": "watermark",
  "Data": "<base64-image>",
  "WatermarkText": "Confidential"
}
```

---

### colorreplace Operation

**Input Parameters:**

```json
{
  "Operation": "colorreplace",
  "Data": "<base64-image>",
  "FromColor": "rgba(255,0,0,255)",
  "ToColor": "rgba(0,0,255,255)"
}
```

---

## Example Use Case in FlowSynx

1. Add the Image Processing plugin to your FlowSynx workflow.
2. Set `Operation` to one of the supported image operations.
3. Provide the image data as a base64 string or byte array in `Data`.
4. Set any additional parameters required for the operation.
5. Use the plugin output downstream in your workflow for further processing or storage.

---

## Debugging Tips

- Ensure `Data` is a valid base64-encoded image or byte array.
- Provide all required parameters for the selected operation.
- For operations like `resize` or `crop`, both `Width` and `Height` are required.
- For `flip`, set `FlipMode` to `horizontal` or `vertical`.
- For `watermark`, provide `WatermarkText`.
- For `colorreplace`, provide both `FromColor` and `ToColor` as strings (e.g., "rgba(255,0,0,255)" or "#FF0000FF").
- If an unsupported operation is specified, an error will be returned.

---

## Security Notes

- No data is persisted unless explicitly configured.
- All operations run in a secure sandbox within FlowSynx.
- Only authorized platform users can view or modify configurations.

---

## License

© FlowSynx. All rights reserved.