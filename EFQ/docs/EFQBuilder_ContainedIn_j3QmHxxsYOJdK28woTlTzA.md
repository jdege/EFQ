#### [EFQ](index.md 'index')
### [JDege.EFQ](JDege_EFQ.md 'JDege.EFQ').[EFQBuilder](EFQBuilder.md 'JDege.EFQ.EFQBuilder')
## EFQBuilder.ContainedIn(string, IEnumerable&lt;object&gt;) Method
returns a EFQ that is true if fieldName is equal to one of the objects  
```csharp
public static JDege.EFQ.EFQ ContainedIn(string fieldName, System.Collections.Generic.IEnumerable<object> objects);
```
#### Parameters
<a name='JDege_EFQ_EFQBuilder_ContainedIn(string_System_Collections_Generic_IEnumerable_object_)_fieldName'></a>
`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the field to compare against
  
<a name='JDege_EFQ_EFQBuilder_ContainedIn(string_System_Collections_Generic_IEnumerable_object_)_objects'></a>
`objects` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The collection of objects that fieldName is compared to
  
#### Returns
[EFQ](EFQ.md 'JDege.EFQ.EFQ')  
EFQ
