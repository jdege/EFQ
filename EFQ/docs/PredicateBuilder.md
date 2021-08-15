#### [EFQ](index.md 'index')
### [PeteMontgomery.PredicateBuilder](PeteMontgomery_PredicateBuilder.md 'PeteMontgomery.PredicateBuilder')
## PredicateBuilder Class
http://petemontgomery.wordpress.com/2011/02/10/a-universal-predicatebuilder/  
Enables the efficient, dynamic composition of query predicates.  
```csharp
public static class PredicateBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; PredicateBuilder  

| Methods | |
| :--- | :--- |
| [And&lt;T&gt;(Expression&lt;Func&lt;T,bool&gt;&gt;, Expression&lt;Func&lt;T,bool&gt;&gt;)](PredicateBuilder_And_xJa9TVvJkcIVL40odtdOEg.md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.And&lt;T&gt;(System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;)') | Combines the first predicate with the second using the logical "and".<br/> |
| [Compose&lt;T&gt;(Expression&lt;T&gt;, Expression&lt;T&gt;, Func&lt;Expression,Expression,Expression&gt;)](PredicateBuilder_Compose_8_87DyUK7+8+RrpuBLR91Q.md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.Compose&lt;T&gt;(System.Linq.Expressions.Expression&lt;T&gt;, System.Linq.Expressions.Expression&lt;T&gt;, System.Func&lt;System.Linq.Expressions.Expression,System.Linq.Expressions.Expression,System.Linq.Expressions.Expression&gt;)') | Combines the first expression with the second using the specified merge function.<br/> |
| [Create&lt;T&gt;(Expression&lt;Func&lt;T,bool&gt;&gt;)](PredicateBuilder_Create_OtpKPtn3UoptODEvDmqHmg.md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.Create&lt;T&gt;(System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;)') | Creates a predicate expression from the specified lambda expression.<br/> |
| [False&lt;T&gt;()](PredicateBuilder_False_T_().md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.False&lt;T&gt;()') | Creates a predicate that evaluates to false.<br/> |
| [Not&lt;T&gt;(Expression&lt;Func&lt;T,bool&gt;&gt;)](PredicateBuilder_Not_bgzg29YG9yM+Ml6vhpnh+A.md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.Not&lt;T&gt;(System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;)') | Negates the predicate.<br/> |
| [Or&lt;T&gt;(Expression&lt;Func&lt;T,bool&gt;&gt;, Expression&lt;Func&lt;T,bool&gt;&gt;)](PredicateBuilder_Or_moTer6bjFygyMjnl_L8UZg.md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.Or&lt;T&gt;(System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;)') | Combines the first predicate with the second using the logical "or".<br/> |
| [True&lt;T&gt;()](PredicateBuilder_True_T_().md 'PeteMontgomery.PredicateBuilder.PredicateBuilder.True&lt;T&gt;()') | Creates a predicate that evaluates to true.<br/> |
