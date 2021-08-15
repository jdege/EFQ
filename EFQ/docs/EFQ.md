#### [EFQ](index 'index')
### [JDege.EFQ](JDege_EFQ 'JDege.EFQ')
## EFQ Class
EFQ is an object that can contain a serialized expression tree that can be   
serialized and deserialized, and which can be used to generate an   
predicate that can be passed to an Entity Framework Where() function.  
  
This should be generally considered as an opaque type. EFQs are constructed  
using the static methods in the EFQBuilder class, serialized and  
deserialized using the System.Text.Json or Newtonsoft.Json converters,  
and are converted into predicates using the extension methods in EFQExtensions.  
```csharp
public class EFQ
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EFQ  
