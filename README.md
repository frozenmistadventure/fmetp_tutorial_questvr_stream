# fmetp_tutorial_questvr_stream

- The Main Branch syncs with the latest FMETP STREAM 6
- For FMETP STREAM 4.0, please refer to BranchV4: https://github.com/frozenmistadventure/fmetp_tutorial_questvr_stream/tree/BranchV4

<STRONG>fmetp_tutorial_questvr_stream</STRONG> is a Oculus VR Streaming tutorial template for <STRONG>FMETP STREAM</STRONG>, it means that FMETP STREAM is required.
- full tutorial video on Youtube (10mins): https://youtu.be/KXmDvOG0hfo

![fmetp_tutorial_oculus_test1](https://user-images.githubusercontent.com/59368610/116001877-6eefa080-a629-11eb-8f5a-28bd9a8ec1d3.gif)

<STRONG>FMETP STREAM</STRONG> share your Game View to any platforms.
Adding Live Stream feature into your apps with ease!

- Asset Store Link(V6 with VP8 support): https://assetstore.unity.com/packages/slug/307623
- Asset Store Link(V4 old version): https://assetstore.unity.com/packages/slug/282061


<STRONG>FM Remote Desktop</STRONG> is our latest Add-on feature, Quest 2 VR Desktop Control template is included in the github project.

- Asset Store link(V2 compatible for FMETP STREAM 6): https://assetstore.unity.com/packages/slug/307908
- Asset Store link(V1 compatible for FMETP STREAM V3, V4): https://assetstore.unity.com/packages/slug/242857

![FMRemoteDesktopCover](https://user-images.githubusercontent.com/59368610/211217499-3ff785bb-0229-45f6-9d96-a46593e61043.png)


<STRONG>FM Polygon Japan</STRONG> is used for tutorial video only. You may check it out if you are interested.

- Asset Store Link: https://assetstore.unity.com/packages/slug/176021

Support: thelghome@gmail.com

<STRONG>Benchmark result(updates in 2024-05-17)</STRONG>
- Upgrade to the latest Meta XR Core SDK(v65), with Unity 2023.2.20f1, XR Plugin Management(v4.4.0)

<STRONG>Benchmark result(updates in 2023-11-03)</STRONG>
- It is running at 120fps(or above) in game during the streaming(1920x1080@30fps) with Unity 2022.3.8f1, XR(v4.0.0), Oculus Integration SDK(v57)
![framerate_test-quest2](https://github-production-user-asset-6210df.s3.amazonaws.com/59368610/280105297-dbe21293-6e58-47f3-8317-2c8eb6742464.jpg)

<STRONG>Stereo Rendering Mode notes for the latest Oculus Integration SDK(v57)</STRONG>
- NOTES for FMETP STREAM V6 (*updated 2025/01/14)
- It's fully compatible with URP VR from FMETP STREAM 6. You can use MainCam mode in URP VR headset for both Meta Quest and Apple Vision Pro from V6.
- You can checkout this github branch "BranchURP" and find the demo scene "QuestVR_StreamSender(UDP)_mainCam(URP-FMETP-STREAM6)"
- other version:
- NOTES for FMETP STREAM V3, V4
- tested MultiPass supports these Capture Modes: MainCam(Built-in), RenderCam(Built-in, URP)
- tested Multiview supports these Capture Modes: RenderCam(Built-in)
- if you are working on URP, please refer to scene "QuestVR_StreamSender(UDP)_renderCam(URP-reference)", and search "RenderCam(GameViewEncoder)" in the scene.
