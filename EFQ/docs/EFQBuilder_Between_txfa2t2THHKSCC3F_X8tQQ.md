#### [EFQ](index.md 'index')
### [JDege.EFQ](JDege_EFQ.md 'JDege.EFQ').[EFQBuilder](EFQBuilder.md 'JDege.EFQ.EFQBuilder')
## EFQBuilder.Between(string, object, object) Method
returns a EFQ that is true if fieldName is greater than or equal to left  
and less than or equal to right  
```csharp
public static JDege.EFQ.EFQ Between(string fieldName, object left, object right);
```
#### Parameters
<a name='JDege_EFQ_EFQBuilder_Between(string_object_object)_fieldName'></a>
`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the field to compare against
  
<a name='JDege_EFQ_EFQBuilder_Between(string_object_object)_left'></a>
`left` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
the lower bound of the comparison
  
<a name='JDege_EFQ_EFQBuilder_Between(string_object_object)_right'></a>
`right` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
the upper bound of the comparison
  
#### Returns
[EFQ](EFQ.md 'JDege.EFQ.EFQ')  
EFQ
