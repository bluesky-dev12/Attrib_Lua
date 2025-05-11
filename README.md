# 🛠️ Atribulatorulator - Lua & Shader Automation Tool

**Atribulatorulator** is an extension of the `attribulator/Atribulatorator` project. This tool automates the workflow of **decompiling**, **editing**, and **compiling** Lua scripts, Vault files, and Shaders for game development or modding.

---

## 🚦 Branch System

The tool supports two working branches for flexibility:

- **TestBranch** – Use during development and debugging.
- **StableBranch** – Use for polished and final builds.

Place your game files under the appropriate branch context.

---

## 📂 Project Structure

```
/Files
├── /Shader                   # Shader source files
└── /UnpackVLT
    ├── /Lua
    │   └── /Decompiled       # Decompiled Lua scripts
    └── /Vault                # Decompiled Vault files
```

---

## ▶️ Getting Started

### 1. Decompile Game Files

Choose the correct `.bat` file based on your branch:

- `Decompile_TestBranch.bat`
- `Decompile_FinalBranch.bat`

**Edit the batch file command:**
```bash
Attribulatorulator.exe -DecompileTestBranch Game
```

Run the `.bat` file. Decompiled content will appear in:

- `Files/UnpackVLT/Lua/Decompiled/`
- `Files/UnpackVLT/Vault/`

---

### 2. Edit Lua Scripts

Modify Lua files freely inside:
```
Files/UnpackVLT/Lua/Decompiled/
```

---

### 3. Compile Game Files

After editing, compile the content back using:

- `Compile_TestBranch.bat`
- `Compile_FinalBranch.bat`

**Example command inside the `.bat`:**
```bash
Attribulatorulator.exe -CompileTestBranch Game
```

---

## 🎨 Shader Compilation

To work with shaders:

1. Place your `.fx` or other shader files in:
   ```
   Files/Shader/
   ```

2. Run the appropriate shader compiler batch:
   - `Compile_ShaderTestBranch.bat`
   - `Compile_ShaderFinalBranch.bat`

---

## ✅ Summary Table

| Task            | Branch       | Output Location                         |
|-----------------|--------------|------------------------------------------|
| Decompile Game  | Test/Final   | `Files/UnpackVLT/Lua/Decompiled/`, Vault |
| Edit Scripts    | -            | `Files/UnpackVLT/Lua/Decompiled/`        |
| Compile Game    | Test/Final   | Via respective batch files               |
| Shader Compile  | Test/Final   | Input: `Files/Shader/`                   |

---

## 📄 License

MIT or follow the license of the original `attribulator/Atribulatorator`.

---

## 🙌 Credits
# RX - Owner of nfsco for original Idea.
# Leo - for attribulator.
# Me - Coding and make this possible.
