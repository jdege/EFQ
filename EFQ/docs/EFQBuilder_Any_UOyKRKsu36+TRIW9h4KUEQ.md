#### [EFQ](index.md 'index')
### [JDege.EFQ](JDege_EFQ.md 'JDege.EFQ').[EFQBuilder](EFQBuilder.md 'JDege.EFQ.EFQBuilder')
## EFQBuilder.Any(string, EFQ) Method
returns a EFQ that is true if the innerCriteria evaluates true  
on the fieldName. (Assumes fieldName is a one-to-many navigational property).  
```csharp
public static JDege.EFQ.EFQ Any(string fieldName, JDege.EFQ.EFQ innerCriteria);
```
#### Parameters
<a name='JDege_EFQ_EFQBuilder_Any(string_JDege_EFQ_EFQ)_fieldName'></a>
`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The name of a navigation property
  
<a name='JDege_EFQ_EFQBuilder_Any(string_JDege_EFQ_EFQ)_innerCriteria'></a>
`innerCriteria` [EFQ](EFQ.md 'JDege.EFQ.EFQ')  
An EFQ that is applied to the navigation property
  
#### Returns
[EFQ](EFQ.md 'JDege.EFQ.EFQ')  
EFQ
