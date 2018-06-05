using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    /*
     - this model class includes all those properties from central json schema which are currently used/mapped to old CSV file properties!!!
     - has to be extended whenever more props are needed in future...
    */

    public class OrderDiscount
    {
        public string promotion_identifier { get; set; }
    }

    public class Origin
    {
        public string sales_channel { get; set; }
        public string locale { get; set; }
    }

    public class PaymentProviderData
    {
        public string payment_provider_transaction_id { get; set; }
        public string pseudo_card_number { get; set; }
        public string card_expiry_date { get; set; }
        public string card_brand { get; set; }
        public string order_description { get; set; }
        public string payment_provider_payment_id { get; set; }
        public string payment_provider_status { get; set; }
        public string payment_provider_order_description { get; set; }
        public string payment_provider_code { get; set; }
        public string sender_holder { get; set; }
        public string account_number { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string bic { get; set; }
        public string country_code { get; set; }
        public string request { get; set; }
        public string response { get; set; }
    }

    public class OrderPayment
    {
        public string type { get; set; }
        public double value { get; set; }
        public PaymentProviderData payment_provider_data { get; set; }
    }

    public class ShippingTotalsGross
    {
        public double? standard { get; set; }
        public double? express { get; set; }
        public double? bulky_goods { get; set; }
        public double? dangerous_goods { get; set; }
    }

    public class PaymentExpensesGross
    {
        public double? cash_on_delivery { get; set; }
    }

    public class Totals
    {
        public ShippingTotalsGross shipping_totals_gross { get; set; }
        public PaymentExpensesGross payment_expenses_gross { get; set; }
        public double? total_discount_gross { get; set; }
    }

    public class Customer
    {
        public string customer_email { get; set; }
    }

    public class BillingAddress
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country_code { get; set; }
    }

    public class ShippingAddress
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country_code { get; set; }
    }

    public class SalesOrderHeader
    {
        public string order_number { get; set; }
        public string order_datetime { get; set; }
        public string order_timezone { get; set; }
        public string order_currency { get; set; }
        public Origin origin { get; set; }
        public List<OrderDiscount> discounts { get; set; }
        public List<OrderPayment> payments { get; set; }
        public Totals totals { get; set; }
        public Customer customer { get; set; }
        public BillingAddress billing_address { get; set; }
        public List<ShippingAddress> shipping_addresses { get; set; }
    }

    public class PartIdentificationProperties
    {
        public string car_type_number { get; set; }
        public string hsn { get; set; }
        public string tsn { get; set; }
    }

    public class ItemNumbers
    {
        public string data_supplier_number { get; set; }
        public string manufacturer_product_number { get; set; }
    }

    public class Order
    {
        public string name { get; set; }
    }

    public class OrderItemInformation
    {
        public string PriceHammer { get; set; }
        public Order order { get; set; }
    }

    public class Creator2
    {
        public string creator_name { get; set; }
    }

    public class SumValues
    {
        public double? sales_value_gross { get; set; }
    }

    public class UnitValues
    {
        public double? sales_value_gross { get; set; }
    }

    public class SalesOrderItem
    {
        public string sku { get; set; }
        public double quantity { get; set; }
        public PartIdentificationProperties part_identification_properties { get; set; }
        public ItemNumbers item_numbers { get; set; }
        public OrderItemInformation item_information { get; set; }
        public Creator2 creator { get; set; }
        public SumValues sum_values { get; set; }
        public UnitValues unit_values { get; set; }
    }

    public class LogisticalUnit
    {
        public string shipping_type { get; set; }
    }

    public class EcpSalesOrderDto
    {
        public SalesOrderHeader order_header { get; set; }
        public List<SalesOrderItem> order_rows { get; set; }
        public List<LogisticalUnit> logistical_units { get; set; }
    }
}
