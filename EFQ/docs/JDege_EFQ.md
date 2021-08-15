#### [EFQ](index.md 'index')
## JDege.EFQ Namespace

| Classes | |
| :--- | :--- |
| [ApplicationBuilderExtensions](ApplicationBuilderExtensions.md 'JDege.EFQ.ApplicationBuilderExtensions') | Extension methods for IApplicationBuilder<br/> |
| [EFQ](EFQ.md 'JDege.EFQ.EFQ') | EFQ is an object that can contain a serialized expression tree that can be <br/>serialized and deserialized, and which can be used to generate an <br/>predicate that can be passed to an Entity Framework Where() function.<br/><br/>This should be generally considered as an opaque type. EFQs are constructed<br/>using the static methods in the EFQBuilder class, serialized and<br/>deserialized using the System.Text.Json or Newtonsoft.Json converters,<br/>and are converted into predicates using the extension methods in EFQExtensions.<br/> |
| [EFQ.Constant](EFQ_Constant.md 'JDege.EFQ.EFQ.Constant') | EFQ.Constant wraps constant values in a way that can be reliably serialized and deserialized.<br/> |
| [EFQBuilder](EFQBuilder.md 'JDege.EFQ.EFQBuilder') | EFQBuilder provides a set of static methods that construct EFQ objects with<br/>various types of expressions.<br/> |
| [EFQExtensions](EFQExtensions.md 'JDege.EFQ.EFQExtensions') | EFQExtensions provides extension methods on EFQ that are used to construct predicates (Expression<Func<T, bool>>>)<br/>that can be passed as arguments to Entity Framework's Where() method.<br/> |

| Enums | |
| :--- | :--- |
| [EFQType](EFQType.md 'JDege.EFQ.EFQType') | The EFQType enum lists the various types of expressions that an EFQ might support.<br/> |
