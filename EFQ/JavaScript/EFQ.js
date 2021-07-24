var EFQ = (function ()
{
	'use strict';

	function EFQ(selectionComparison, fieldName, fieldValue, aggregateList, innerCriteria)
	{
		this.selectionComparison = selectionComparison;
		this.fieldName = fieldName;
		this.fieldValue = fieldValue;
		this.aggregateList = aggregateList;
		this.innerCriteria = innerCriteria;
	}

	EFQ.compare = function (comparison, fieldName, fieldValue)
	{
		return new EFQ(comparison, fieldName, fieldValue);
	};

	EFQ.isTrue = function ()
	{
		return new EFQ("IsTrue");
	};

	EFQ.isFalse = function ()
	{
		return new EFQ("IsFalse");
	};

	EFQ.contains = function (fieldName, fieldValue)
	{
		return new EFQ("Contains", fieldName, fieldValue);
	};

	EFQ.startsWith = function (fieldName, fieldValue)
	{
		return new EFQ("StartsWith", fieldName, fieldValue);
	};

	EFQ.endsWith = function (fieldName, fieldValue)
	{
		return new EFQ("EndsWith", fieldName, fieldValue);
	};

	EFQ.like = function (fieldName, fieldValue)
	{
		return new EFQ("Like", fieldName, fieldValue);
	};

	EFQ.any = function (fieldName, innerCriteria)
	{
		return new EFQ("Any", fieldName, null, null, innerCriteria);
	};

	EFQ.equal = function (fieldName, fieldValue)
	{
		return new EFQ("Equal", fieldName, fieldValue);
	};

	EFQ.notEqual = function (fieldName, fieldValue)
	{
		return new EFQ("NotEqual", fieldName, fieldValue);
	};

	EFQ.greaterThan = function (fieldName, fieldValue)
	{
		return new EFQ("GreaterThan", fieldName, fieldValue);
	};

	EFQ.greaterThanOrEqual = function (fieldName, fieldValue)
	{
		return new EFQ("GreaterThanOrEqual", fieldName, fieldValue);
	};

	EFQ.lessThan = function (fieldName, fieldValue)
	{
		return new EFQ("LessThan", fieldName, fieldValue);
	};

	EFQ.lessThanOrEqual = function (fieldName, fieldValue)
	{
		return new EFQ("LessThanOrEqual", fieldName, fieldValue);
	};

	EFQ.and = function (selectionCriteriae)
	{
		return new EFQ("And", undefined, undefined, selectionCriteriae);
	};

	EFQ.or = function (selectionCriteriae)
	{
		return new EFQ("Or", undefined, undefined, selectionCriteriae);
	};

	EFQ.nand = function (selectionCriteriae)
	{
		return new EFQ("Nand", undefined, undefined, selectionCriteriae);
	};

	EFQ.nor = function (selectionCriteriae)
	{
		return new EFQ("Nor", undefined, undefined, selectionCriteriae);
	};

	EFQ.not = function (selectionCriteria)
	{
		return new EFQ("Nand", undefined, undefined, [selectionCriteria]);
	};

	EFQ.containedIn = function (fieldName, values)
	{
		var criteriae = [];
		for (var i = 0; i < values.length; i++)
			criteriae.push(EFQ.equal(fieldName, values[i]));

		return new EFQ("Or", undefined, undefined, criteriae);
	};

	EFQ.between = function (fieldName, left, right)
	{
		var criteriae = [
			EFQ.greaterThanOrEqual(fieldName, left),
			EFQ.lessThanOrEqual(fieldName, right)
		];
		return new EFQ("And", undefined, undefined, criteriae);
	};

	return EFQ;

})();

