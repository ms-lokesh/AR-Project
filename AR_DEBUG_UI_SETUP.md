# AR Debug UI Setup Instructions

## 🎯 Quick Setup (5 minutes)

### Step 1: Add Debug Scripts to SampleScene

1. **Open SampleScene** in Unity
2. **Create Debug UI GameObject:**
   - Right-click in Hierarchy → UI → Canvas
   - Rename it to "ARDebugCanvas"
   - Set Canvas Scaler → UI Scale Mode → "Scale With Screen Size"
   - Reference Resolution: 1080 x 1920

### Step 2: Add Status Text

1. **In ARDebugCanvas**, right-click → UI → **Text - TextMeshPro**
2. Rename to "StatusText"
3. Settings:
   - Anchor: Top Center
   - Position Y: -100
   - Width: 900, Height: 150
   - Font Size: 36
   - Alignment: Center
   - Color: White
   - Text: "Point camera at image"
   - Add **Outline** component (black, size 2)

### Step 3: Add Debug Info Panel

1. **In ARDebugCanvas**, right-click → UI → **Panel**
2. Rename to "DebugPanel"
3. Position: Top Left corner
4. Width: 600, Height: 500
5. **Add Text child:**
   - Right-click DebugPanel → UI → Text - TextMeshPro
   - Rename to "DebugInfoText"
   - Anchor: Stretch all
   - Margins: 20 on all sides
   - Font Size: 24
   - Alignment: Top Left
   - Color: White

### Step 4: Add Scan Button

1. **In ARDebugCanvas**, right-click → UI → **Button - TextMeshPro**
2. Rename to "ScanButton"
3. Settings:
   - Anchor: Bottom Center
   - Position Y: 150
   - Width: 400, Height: 100
   - Button text: "Start Scanning"
   - Font Size: 36
   - Button Color: Green

### Step 5: Add ARDebugUI Script

1. **Select ARDebugCanvas** GameObject
2. **Add Component** → Search "ARDebugUI"
3. **Assign References:**
   - Status Text → Drag "StatusText" from Hierarchy
   - Tracked Images Text → Drag "DebugInfoText" from Hierarchy
   - Scan Button → Drag "ScanButton" from Hierarchy
   - Debug Panel → Drag "DebugPanel" from Hierarchy
   - AR Session → Find "AR Session" in Hierarchy and drag
   - Tracked Image Manager → Find "XR Origin" → drag AR Tracked Image Manager component
   - Camera Manager → Drag AR Camera Manager from XR Origin

### Step 6: Optional - Visual Feedback

1. **Create a simple indicator:**
   - Create → 3D Object → Quad
   - Rename to "DetectionIndicator"
   - Scale: 0.2, 0.2, 0.2
   - Add material with bright color
   - Disable it (uncheck in Inspector)

2. **Add Visual Feedback Script:**
   - Select ARDebugCanvas
   - Add Component → "ARVisualFeedback"
   - Drag DetectionIndicator to the field

### Step 7: Save and Build

1. **Save Scene** (Cmd+S)
2. **File → Build Settings → Build and Run**
3. Test on device!

---

## 📱 What You'll See on Device:

### Top (Status Text):
- "Point camera at image"
- When detected: "✅ DETECTED: Heart!"
- When tracking: "👁️ TRACKING: Heart"

### Top Left (Debug Panel):
- AR Session status
- Camera status
- Image Manager status
- Reference Library loaded
- Number of images in library
- Currently tracked images
- Last detected image

### Bottom (Scan Button):
- "Start Scanning" / "Stop Scanning"
- Helps trigger scan mode

---

## 🐛 Interpreting Debug Info:

### If you see:
- ❌ **"Session: Inactive"** → AR Session not running
- ❌ **"Camera: Inactive"** → Camera not working
- ❌ **"Reference Library: Missing"** → Library not linked
- ✅ **"Images in Library: 3"** → All images loaded
- ✅ **"Tracked Images: 1"** → Image detected!

### Common Error Messages:

1. **"Reference Library: Missing"**
   - Fix: Assign ReferenceImageLibrary.asset to AR Tracked Image Manager

2. **"Images in Library: 0"**
   - Fix: Add images to Reference Image Library

3. **"Camera: Inactive"**
   - Fix: Check camera permissions on phone
   - Settings → Apps → TexAR → Permissions → Camera

4. **Detects but no 3D model:**
   - Fix: Check ImageTracker script has prefabs assigned
   - Check prefab names match reference image names

---

## 🎨 Customization:

Want different colors/sizes? Modify in Unity:
- Status Text: Change font size, color, position
- Debug Panel: Resize, reposition, change background
- Scan Button: Change color, text, size

---

## 🔧 Quick Test Commands:

After adding scripts, you can also check logs:

**Android (via ADB):**
```bash
adb logcat | grep "AR Debug\|AR\]\|ImageTracker"
```

**Look for:**
- `[AR] Image Added: Heart` → Image detected!
- `[AR] Image Tracking: Heart` → Actively tracking
- `[AR] Image Removed: Heart` → Lost tracking

---

## ✅ Success Checklist:

After setup, you should see:
- [ ] Status text appears at top
- [ ] Debug panel shows in top left
- [ ] Scan button at bottom
- [ ] Button responds to tap
- [ ] Debug info updates in real-time
- [ ] Status changes when pointing at image
- [ ] Console logs show detection events

---

## 🎯 Next Steps After Setup:

1. **Build and install** on phone
2. **Open app** → Go to Scan section
3. **Watch debug panel** - it should show:
   - AR Session: ✅ Active
   - Camera: ✅ Active
   - Images in Library: 3
4. **Point at printed image**
5. **Watch status text** for detection message
6. **Check debug panel** for "Tracked Images" count

If you see detection but no 3D model, then we know the issue is in the ImageTracker script or prefab spawning, not the image detection itself!
