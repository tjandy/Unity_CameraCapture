# Unity_CameraCapture
unity中批量截图工具

给美术使用的脚本，把场景中的3d对象批量截图

原理：遍历场景中的对象，然后摄像机偏移截图

使用说明：

1、建一个不带天空盒的相机

2、把需要截图对象的Tag设置成player

3、把CameraCaptureEditor脚本挂在场景里就行

注意点：

1、摄像机的alpha需要设置为0

2、目前截图尺寸大小（800，600），相机偏移量(2) 是写在脚本里的
