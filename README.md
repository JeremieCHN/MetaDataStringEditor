# global-metadata.dat的部分字符串修改工具
&emsp;&emsp;对于Unity-il2cpp脚本后端导出的Android游戏，代码中出现的字符串会编译进assets\bin\Data\Managed\Metadata\global-metadata.dat文件，作为汉化工作的一环，简单撸了一个工具对其中的字符串做修改。
## 参考资料
- [il2cppdumper](https://github.com/Perfare/Il2CppDumper)<br>
对该文件内容的理解都是从这个工具的源码学到的，这个工具本身是用来从编译后的libil2cpp.so文件和global-metadata.dat文件里面导出类的定义，导出形式包括IDA可用的重命名脚本、UABE和AssetStudio可用的DLL等，是个很好用的工具。
## 修改内容
&emsp;&emsp;在global-metadata.dat中，对代码中的字符串的保存方式如下是，头部有一个列表放每一个字符串的偏移量、长度等信息，然后在数据区有一个区域直接紧凑放所有的字符串，有头部的列表，所以不需要\0结尾。<br>
&emsp;&emsp;因为修改前后字符串数量不变，所以对列表的修改是直接在原来的区域上覆盖。数据区的长度可能发生变化，如果修改过后，数据区的长度小于等于原先的长度，则直接覆盖写入，如果过长，则写入到文件尾。
