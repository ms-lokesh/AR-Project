# TexAR - AR Image Tracking Setup Checklist

## ✅ Current Status (All Configured):
1. ✅ ARSession in SampleScene
2. ✅ XR Origin with ARTrackedImageManager
3. ✅ ImageTracker script configured
4. ✅ ReferenceImageLibrary linked
5. ✅ 3 Prefabs assigned (Heart, Neuron, CircuitSystem)
6. ✅ All textures assigned to reference images

## ⚠️ TO FIX IN UNITY:

### 1. Enable "Keep Texture At Runtime" (CRITICAL)
1. Open Unity
2. Select **ReferenceImageLibrary.asset** in Project panel
3. In Inspector, for EACH image (Heart, Neuron, CircuitSystem):
   - Expand the image entry
   - Check ✅ **"Keep Texture At Runtime"**
4. Save (Cmd+S)

### 2. Remove Duplicate ImageTracker (Optional - for cleanup)
1. In SampleScene Hierarchy
2. Find standalone "ImageTracker" GameObject (NOT the one on XR Origin)
3. Delete it
4. Save scene

### 3. Verify Image Sizes
Current sizes in library:
- CircuitSystem: 0.15m (15cm) wide
- Neuron: 0.15m (15cm) wide
- Heart: 0.15m (15cm) wide

Make sure your PRINTED images are approximately this size!

## 📱 TESTING REQUIREMENTS:

### What You NEED:
✅ **PRINTED images** from NCERT textbook (actual paper)
✅ **Good lighting** (not too dark, not too bright)
✅ **Flat surface** (not curved/wrinkled)
✅ **Hold phone 30-50cm** away from image
✅ **Keep entire image** in camera view
✅ **Hold steady** for 2-3 seconds

### What WON'T Work:
❌ Images displayed on another phone/tablet screen
❌ Very small or very large images (must match 15cm width)
❌ Poor lighting
❌ Moving phone too fast
❌ Curved/wrinkled/damaged images

## 🔄 After Making Changes:

1. **In Unity:**
   - Enable "Keep Texture At Runtime" for all 3 images
   - Save everything (Cmd+S)
   
2. **Rebuild:**
   - File → Build Settings → Build and Run
   
3. **Test on Phone:**
   - Use PRINTED NCERT images
   - Good lighting
   - Hold steady 30-50cm away
   - Wait 2-3 seconds for detection

## 🐛 If Still Not Working:

Check Unity Console (in Editor):
- Window → General → Console
- Look for red errors related to AR or ImageTracker

Check Logcat (Android):
```bash
adb logcat | grep -i "AR\|Unity\|ImageTracker"
```

## 📋 Reference Image Requirements:

For best tracking:
- **High contrast** (clear details, not blurry)
- **Good resolution** (at least 300dpi when printed)
- **Distinctive features** (unique patterns, not plain)
- **Flat and undamaged**
- **Well-lit** (no shadows, no glare)

## 🎯 Expected Behavior:

When working correctly:
1. Open app → Navigate to Scan section
2. Camera opens
3. Point at PRINTED heart image
4. After 1-2 seconds, 3D heart model appears
5. Model stays attached to image as you move phone
6. Model disappears when image not in view
