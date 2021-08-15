#### [EFQ](index 'index')
### [JDege.EFQ](JDege_EFQ 'JDege.EFQ').[EFQExtensions](EFQExtensions 'JDege.EFQ.EFQExtensions')
## EFQExtensions.ConstructPredicate&lt;T&gt;(EFQ, Dictionary&lt;string,Constant&gt;) Method
Construct the Entity Framweork predicate  
```csharp
public static System.Linq.Expressions.Expression<System.Func<T,bool>> ConstructPredicate<T>(this JDege.EFQ.EFQ efq, System.Collections.Generic.Dictionary<string,JDege.EFQ.EFQ.Constant> paramDict=null);
```
#### Type parameters
<a name='JDege_EFQ_EFQExtensions_ConstructPredicate_T_(JDege_EFQ_EFQ_System_Collections_Generic_Dictionary_string_JDege_EFQ_EFQ_Constant_)_T'></a>
`T`  
The base type of the collection that the query will be run against. This should be a DbSet.
  
#### Parameters
<a name='JDege_EFQ_EFQExtensions_ConstructPredicate_T_(JDege_EFQ_EFQ_System_Collections_Generic_Dictionary_string_JDege_EFQ_EFQ_Constant_)_efq'></a>
`efq` [EFQ](EFQ 'JDege.EFQ.EFQ')  
this EFQ
  
<a name='JDege_EFQ_EFQExtensions_ConstructPredicate_T_(JDege_EFQ_EFQ_System_Collections_Generic_Dictionary_string_JDege_EFQ_EFQ_Constant_)_paramDict'></a>
`paramDict` [System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Constant](EFQ_Constant 'JDege.EFQ.EFQ.Constant')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')  
A dictionary of named constants to be substituted when building the predicate
  
#### Returns
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EFQExtensions_ConstructPredicate_cXg68S2IdsdYbPLIg0Tc+w#JDege_EFQ_EFQExtensions_ConstructPredicate_T_(JDege_EFQ_EFQ_System_Collections_Generic_Dictionary_string_JDege_EFQ_EFQ_Constant_)_T 'JDege.EFQ.EFQExtensions.ConstructPredicate&lt;T&gt;(JDege.EFQ.EFQ, System.Collections.Generic.Dictionary&lt;string,JDege.EFQ.EFQ.Constant&gt;).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
The predicate (an Expression tree)
