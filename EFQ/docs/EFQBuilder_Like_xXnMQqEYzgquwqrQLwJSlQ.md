#### [EFQ](index.md 'index')
### [JDege.EFQ](JDege_EFQ.md 'JDege.EFQ').[EFQBuilder](EFQBuilder.md 'JDege.EFQ.EFQBuilder')
## EFQBuilder.Like(string, object) Method
returns a EFQ that is true if fieldName matches rightHandSide as a SQL LIKE pattern  
```csharp
public static JDege.EFQ.EFQ Like(string fieldName, object rightHandSide);
```
#### Parameters
<a name='JDege_EFQ_EFQBuilder_Like(string_object)_fieldName'></a>
`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of the field to compare against
  
<a name='JDege_EFQ_EFQBuilder_Like(string_object)_rightHandSide'></a>
`rightHandSide` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
A constant value or an EFQ that is used to compare
  
#### Returns
[EFQ](EFQ.md 'JDege.EFQ.EFQ')  
EFQ