# How to Build and Deploy Stellar Protocol to GitHub Pages

The game is deployed to GitHub Pages from the `Docs/` directory. For the game to work, the Unity WebGL build files must be placed in `Docs/Build/`.

## Steps to Build:

1. **Open Unity**: Open the project in Unity.
2. **Build Settings**:
   - Go to `File` -> `Build Settings`.
   - Select **WebGL** platform.
   - Click `Switch Platform` if needed.
   - Click `Player Settings` -> `Player` -> `Resolution and Presentation`.
   - Ensure the "WebGL Template" is set to "Minimal" or default (we are using a custom `index.html` in `Docs/`, so the template matters less for the file structure, but standard settings are best).
   - **Important**: In `Publishing Settings`, ensure "Compression Format" is set to "Disabled" or "Gzip" (Brotli requires https configuration which GH Pages supports, but Disabled is safest for debugging).

3. **Build**:
   - Click `Build`.
   - When asked for a location, create a folder named `Build` inside the `Docs` folder of your project root.
   - **Path**: `[ProjectRoot]/Docs/Build`
   - **File Name**: Name the build `Stellar Protocol`.

## Verify Files:

After building, your `Docs/Build/` folder should contain files like:
- `Stellar Protocol.loader.js`
- `Stellar Protocol.data`
- `Stellar Protocol.framework.js`
- `Stellar Protocol.wasm`

(If you named it differently, e.g., "WebGL", the files will be named `WebGL.loader.js`, etc. The `index.html` supports both names).

## Commit and Push:

1. Add the new files to git:
   ```bash
   git add Docs/Build/
   ```
   *Note: If git ignores the files, check `.gitignore`. It is configured to allow `Docs/Build/`, so it should work.*

2. Commit:
   ```bash
   git commit -m "Add WebGL build files"
   ```

3. Push:
   ```bash
   git push origin main
   ```

## Troubleshooting

- If the website says "Loading..." and then shows an error message, read the error message carefully.
- If it says "Could not load game files", it means the browser cannot find the `.loader.js` file. Check the file names in `Docs/Build/`.
