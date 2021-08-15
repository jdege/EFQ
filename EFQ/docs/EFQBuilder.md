#### [EFQ](index 'index')
### [JDege.EFQ](JDege_EFQ 'JDege.EFQ')
## EFQBuilder Class
EFQBuilder provides a set of static methods that construct EFQ objects with  
various types of expressions.  
```csharp
public class EFQBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EFQBuilder  

| Methods | |
| :--- | :--- |
| [Add(object, object)](EFQBuilder_Add_MB_9FBH_SCKzFlQRdcBeOw 'JDege.EFQ.EFQBuilder.Add(object, object)') | Returns an EFQ that adds two constant values.<br/><br/>This was developed to support adding TimeSpans to DateTime.Now values.<br/>It allows the construction of queries that, for example, return all records<br/>where a date is greater than now-minus-30-days.<br/> |
| [And(EFQ[])](EFQBuilder_And_c6PXumKvUCADEI56oZxCiw 'JDege.EFQ.EFQBuilder.And(JDege.EFQ.EFQ[])') | returns a EFQ that is true if all of the efqs evaluate true<br/> |
| [And(IEnumerable&lt;EFQ&gt;)](EFQBuilder_And_ONPCJGLp5YvkSssPJgCrsw 'JDege.EFQ.EFQBuilder.And(System.Collections.Generic.IEnumerable&lt;JDege.EFQ.EFQ&gt;)') | returns a EFQ that is true if all of the efqs evaluate true<br/> |
| [Any(string, EFQ)](EFQBuilder_Any_UOyKRKsu36+TRIW9h4KUEQ 'JDege.EFQ.EFQBuilder.Any(string, JDege.EFQ.EFQ)') | returns a EFQ that is true if the innerCriteria evaluates true<br/>on the fieldName. (Assumes fieldName is a one-to-many navigational property).<br/> |
| [Between(string, object, object)](EFQBuilder_Between_txfa2t2THHKSCC3F_X8tQQ 'JDege.EFQ.EFQBuilder.Between(string, object, object)') | returns a EFQ that is true if fieldName is greater than or equal to left<br/>and less than or equal to right<br/> |
| [Constant(object)](EFQBuilder_Constant_DL5ZoJiixECZy_Zz_5Rddg 'JDege.EFQ.EFQBuilder.Constant(object)') | Wraps a constant value in an EFQ<br/> |
| [ContainedIn(string, IEnumerable&lt;object&gt;)](EFQBuilder_ContainedIn_j3QmHxxsYOJdK28woTlTzA 'JDege.EFQ.EFQBuilder.ContainedIn(string, System.Collections.Generic.IEnumerable&lt;object&gt;)') | returns a EFQ that is true if fieldName is equal to one of the objects<br/> |
| [Contains(string, object)](EFQBuilder_Contains_ZzhwlVbXf8vsQmul6eqvwg 'JDege.EFQ.EFQBuilder.Contains(string, object)') | returns a EFQ that is true if fieldName contains rightHandSide as a substring<br/> |
| [EndsWith(string, object)](EFQBuilder_EndsWith_Y3trXjQ0BLn+U59GL5SvCw 'JDege.EFQ.EFQBuilder.EndsWith(string, object)') | returns a EFQ that is true if fieldName ends with rightHandSide as a substring<br/> |
| [Equal(string, object)](EFQBuilder_Equal_JtgcoJO52yTwRHeB4I3G8w 'JDege.EFQ.EFQBuilder.Equal(string, object)') | returns a EFQ that is true if fieldName is equal to rightHandSide<br/> |
| [GreaterThan(string, object)](EFQBuilder_GreaterThan_8OOvWrs5MLVs8X2O4GvISA 'JDege.EFQ.EFQBuilder.GreaterThan(string, object)') | returns a EFQ that is true if fieldName is greater than rightHandSide<br/> |
| [GreaterThanOrEqual(string, object)](EFQBuilder_GreaterThanOrEqual_L71mql+altEZj8+YKLX0Xg 'JDege.EFQ.EFQBuilder.GreaterThanOrEqual(string, object)') | returns a EFQ that is true if fieldName is greater than or equal to rightHandSide<br/> |
| [IsFalse()](EFQBuilder_IsFalse() 'JDege.EFQ.EFQBuilder.IsFalse()') | returns a EFQ that is always false<br/> |
| [IsTrue()](EFQBuilder_IsTrue() 'JDege.EFQ.EFQBuilder.IsTrue()') | returns a EFQ that is always true<br/> |
| [LessThan(string, object)](EFQBuilder_LessThan_syByK4etadgmIshgDt1ujA 'JDege.EFQ.EFQBuilder.LessThan(string, object)') | returns a EFQ that is true if fieldName is less than rightHandSide<br/> |
| [LessThanOrEqual(string, object)](EFQBuilder_LessThanOrEqual_r2hIQuCxJsfaIs4GVLqsxw 'JDege.EFQ.EFQBuilder.LessThanOrEqual(string, object)') | returns a EFQ that is true if fieldName is less than or equal to rightHandSide<br/> |
| [Like(string, object)](EFQBuilder_Like_xXnMQqEYzgquwqrQLwJSlQ 'JDege.EFQ.EFQBuilder.Like(string, object)') | returns a EFQ that is true if fieldName matches rightHandSide as a SQL LIKE pattern<br/> |
| [Nand(EFQ[])](EFQBuilder_Nand_88InV8ew2RrbekYaTavehw 'JDege.EFQ.EFQBuilder.Nand(JDege.EFQ.EFQ[])') | returns a EFQ that is true if at least one of the efqs evaluates false<br/> |
| [Nand(IEnumerable&lt;EFQ&gt;)](EFQBuilder_Nand_tjB2pNNW6ykLpQxW5TLK+Q 'JDege.EFQ.EFQBuilder.Nand(System.Collections.Generic.IEnumerable&lt;JDege.EFQ.EFQ&gt;)') | returns a EFQ that is true if at least one of the efqs evaluates false<br/> |
| [Nor(EFQ[])](EFQBuilder_Nor_f__nqqirbilE4RAEFPQjjw 'JDege.EFQ.EFQBuilder.Nor(JDege.EFQ.EFQ[])') | returns a EFQ that is true if all of the efqs evaluate false<br/> |
| [Nor(IEnumerable&lt;EFQ&gt;)](EFQBuilder_Nor_Q9_KAKImNp_NlAh0fGLTmw 'JDege.EFQ.EFQBuilder.Nor(System.Collections.Generic.IEnumerable&lt;JDege.EFQ.EFQ&gt;)') | returns a EFQ that is true if all of the efqs evaluate false<br/> |
| [Not(EFQ)](EFQBuilder_Not_hUzrMZxPU86KyM8ygqSTgA 'JDege.EFQ.EFQBuilder.Not(JDege.EFQ.EFQ)') | returns a EFQ that is true if efq evaluates false<br/> |
| [NotEqual(string, object)](EFQBuilder_NotEqual_h2LMnIKw6bAPieK+mUKGXg 'JDege.EFQ.EFQBuilder.NotEqual(string, object)') | returns a EFQ that is true if fieldName is not equal to rightHandSide<br/> |
| [Or(EFQ[])](EFQBuilder_Or_k2+PWjNh0vcaKqdBKJPpTg 'JDege.EFQ.EFQBuilder.Or(JDege.EFQ.EFQ[])') | returns a EFQ that is true if at least one of the efqs evaluates true<br/> |
| [Or(IEnumerable&lt;EFQ&gt;)](EFQBuilder_Or_1hGLn1zo97ubaOfAM4fNoQ 'JDege.EFQ.EFQBuilder.Or(System.Collections.Generic.IEnumerable&lt;JDege.EFQ.EFQ&gt;)') | returns a EFQ that is true if at least one of the efqs evaluates true<br/> |
| [StartsWith(string, object)](EFQBuilder_StartsWith_Kj_pqUmLkmiKwP8hronmKg 'JDege.EFQ.EFQBuilder.StartsWith(string, object)') | returns a EFQ that is true if fieldName starts with rightHandSide as a substring<br/> |
