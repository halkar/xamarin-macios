MONO_PATH=/Developer/MonoTouch/usr/lib/mono/2.1/ monodis /Developer/MonoTouch/usr/lib/mono/2.1/monotouch.dll > monotouch.il
for n in `grep [.]namespace *.il | sort | uniq | sed 's/.namespace //'`; do echo "using $n;"; done > sof20696157.cs
echo "namespace Test {" >> sof20696157.cs
C=1; for i in `grep "[.]class interface public" *.il | sed 's/.* //'`; do echo -e "\t[Protocol] interface C$C : $i {}"; let C=$C+1; done >> sof20696157.cs
C=1; for i in `grep "[.]class interface public" *.il | sed 's/.* //'`; do echo -e "\t[Protocol] [BaseType (typeof (NSObject))] interface M$C : $i {}"; let C=$C+1; done >> sof20696157.cs
echo "}" >> sof20696157.cs