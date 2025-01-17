﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonSellerApi.Enums
{
	public enum SchemaVersion
	{
		v1 = 1,
		v2 = 2,
		v3 = 3
	}

    public enum DeliveryMethodStatus
    {
        New = 1,
        Edited = 2,
        Active = 3,
        Disabled = 4
    }


	//public class Language : StringEnum<Language>
	//{
	//	public static Language DEFAULT = New();
	//	public static Language EN = New();
	//	public static Language RU = New();
	//}

	//public class ClassifierStatus : StringEnum<ClassifierStatus>
	//{
	//	public static ClassifierStatus CLASSIFIED = New();
	//	public static ClassifierStatus NOT_CLASSIFIED = New();
	//}

	//public class DeliverySchema : StringEnum<DeliverySchema>
	//{
	//	/// <summary>
	//	/// Fulfilled by Seller
	//	/// </summary>
	//	public static DeliverySchema FBS = New();

	//	/// <summary>
	//	/// Fulfilled by Ozon
	//	/// </summary>
	//	public static DeliverySchema FBO  = New();

	//	/// <summary>
	//	///
	//	/// </summary>
	//	public static DeliverySchema CROSSBORDER  = New();
	//}

	//public class DimensionUnit : StringEnum<DimensionUnit>
	//{
	//	public static DimensionUnit MILLIMETERS = New();
	//	public static DimensionUnit CENTIMETRES = New();
	//	public static DimensionUnit INCHES = New();
	//}

	//public class PostingScheme : StringEnum<PostingScheme>
	//{
	//	public static PostingScheme CROSSBORDER = New();
	//	public static PostingScheme FBO = New();
	//	public static PostingScheme FBS = New();
	//	public static PostingScheme[] All => new PostingScheme[] { CROSSBORDER, FBO, FBS };
	//}

	//public class ProductState : StringEnum<ProductState>
	//{
	//	public static ProductState PROCESSED = New();
	//	public static ProductState PROCESSING = New();
	//	public static ProductState MODERATING = New();
	//	public static ProductState FAILED_MODERATION = New();
	//	public static ProductState FAILED_VALIDATION = New();
	//	public static ProductState FAILED = New();
	//}

	//public class SortDirection : StringEnum<SortDirection>
	//{
	//	public static SortDirection ASC = New();
	//	public static SortDirection DESC = New();
	//}

	//public class OrderStatus : StringEnum<OrderStatus>
	//{
	//	public static OrderStatus AWAITING_APPROVE = New();
	//	public static OrderStatus AWAITING_PACKAGING = New();
	//	public static OrderStatus AWAITING_DELIVER = New();
	//	public static OrderStatus DELIVERING = New();
	//	public static OrderStatus DELIVERED = New();
	//	public static OrderStatus CANCELLED = New();
	//	public static OrderStatus[] All => new OrderStatus[] { AWAITING_APPROVE, AWAITING_PACKAGING, AWAITING_DELIVER, DELIVERING, DELIVERED, CANCELLED };
	//}

	//public class TransactionType : StringEnum<TransactionType>
	//{
	//	public static TransactionType ALL = New();
	//	public static TransactionType ORDERS = New();
	//	public static TransactionType RETURNS = New();
	//	public static TransactionType SERVICES = New();
	//	public static TransactionType OTHER = New();
	//	public static TransactionType DEPOSIT = New();
	//}


	//public class Visibility : StringEnum<Visibility>
	//{
	//	/// <summary>
	//	/// all products
	//	/// </summary>
	//	public static Visibility ALL = New();

	//	/// <summary>
	//	/// products, visible for customers
	//	/// </summary>
	//	public static Visibility VISIBLE = New();

	//	/// <summary>
	//	/// products, invisible for customers for some reason
	//	/// </summary>
	//	public static Visibility INVISIBLE = New();

	//	/// <summary>
	//	/// products with empty stock */
 //   /// </summary>
 //   /// 
 //   public static Visibility EMPTY_STOCK = New();

	//	/// <summary>
	//	/// products with empty stock and state=processed (so you can set stock)
	//	/// </summary>
	//	public static Visibility READY_TO_SUPPLY = New();

	//	/// <summary>
	//	/// products which are failed on some step
	//	/// </summary>
	//	public static Visibility STATE_FAILED = New();
	//}

	//public class WeightUnit : StringEnum<WeightUnit>
	//{
	//	public static WeightUnit GRAMS = New();
	//	public static WeightUnit KILOGRAMS = New();
	//	public static WeightUnit POUNDS = New();
	//}

}

