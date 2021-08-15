#### [EFQ](index 'index')
### [JDege.EFQ](JDege_EFQ 'JDege.EFQ').[EFQBuilder](EFQBuilder 'JDege.EFQ.EFQBuilder')
## EFQBuilder.Add(object, object) Method
Returns an EFQ that adds two constant values.  
  
This was developed to support adding TimeSpans to DateTime.Now values.  
It allows the construction of queries that, for example, return all records  
where a date is greater than now-minus-30-days.  
```csharp
public static JDege.EFQ.EFQ Add(object left, object right);
```
#### Parameters
<a name='JDege_EFQ_EFQBuilder_Add(object_object)_left'></a>
`left` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
<a name='JDege_EFQ_EFQBuilder_Add(object_object)_right'></a>
`right` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
#### Returns
[EFQ](EFQ 'JDege.EFQ.EFQ')  
EFQ
