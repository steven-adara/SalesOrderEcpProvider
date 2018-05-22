using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class Origin
    {
        public string sales_channel { get; set; }
        public string locale { get; set; }
    }

    public class Creator
    {
        public string type { get; set; }
        public string creator_id { get; set; }
        public string creator_name { get; set; }
    }

    public class Discount
    {
        public string discount_name { get; set; }
        public string display_name { get; set; }
        public string discount_code { get; set; }
        public string discount_type { get; set; }
        public string promotion_identifier { get; set; }
    }

    public class AdditionalData
    {
        public string CommunicationToken { get; set; }
    }

    public class PaymentProviderData
    {
        public string code { get; set; }
        public string promotion_identifier { get; set; }
        public string external_id { get; set; }
        public double? transaction_amount { get; set; }
        public string payment_provider_transaction_id { get; set; }
        public string pseudo_card_number { get; set; }
        public string card_expiry_date { get; set; }
        public string card_brand { get; set; }
        public string order_description { get; set; }
        public string payment_provider_payment_id { get; set; }
        public string payment_provider_status { get; set; }
        public string payment_provider_order_description { get; set; }
        public string payment_provider_code { get; set; }
        public string billing_agreement { get; set; }
        public string sender_holder { get; set; }
        public string account_number { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string bic { get; set; }
        public string country_code { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public AdditionalData additional_data { get; set; }
    }

    public class Payment
    {
        public string type { get; set; }
        public double value { get; set; }
        public PaymentProviderData payment_provider_data { get; set; }
        public string payment_transaction_id { get; set; }
    }

    public class ShippingTotalsGross
    {
        public string standard { get; set; }
        public string express { get; set; }
        public string bulky_goods { get; set; }
        public string dangerous_goods { get; set; }
    }

    public class ShippingTotalsNet
    {
        public string standard { get; set; }
        public string express { get; set; }
        public string bulky_goods { get; set; }
        public string dangerous_goods { get; set; }
    }

    public class PaymentExpensesGross
    {
        public string cash_on_delivery { get; set; }
        public string credit_card_payment { get; set; }
    }

    public class PaymentExpensesNet
    {
        public string cash_on_delivery { get; set; }
        public string credit_card_payment { get; set; }
    }

    public class GrandtotalTax
    {
        public string type { get; set; }
        public string value { get; set; }
        public string rate { get; set; }
    }

    public class Totals
    {
        public double goods_total_gross { get; set; }
        public double goods_total_net { get; set; }
        public string sales_value_total_gross { get; set; }
        public string sales_value_total_net { get; set; }
        public double subtotal_gross { get; set; }
        public double subtotal_net { get; set; }
        public ShippingTotalsGross shipping_totals_gross { get; set; }
        public ShippingTotalsNet shipping_totals_net { get; set; }
        public PaymentExpensesGross payment_expenses_gross { get; set; }
        public PaymentExpensesNet payment_expenses_net { get; set; }
        public string grandtotal_gross { get; set; }
        public string grandtotal_net { get; set; }
        public List<GrandtotalTax> grandtotal_taxes { get; set; }
        public double total_discount_gross { get; set; }
        public double total_discount_net { get; set; }
        public double payment_total { get; set; }
    }

    public class TrustNPayScore
    {
        public string communication_token { get; set; }
        public string result { get; set; }
    }

    public class RiskCheck
    {
        public TrustNPayScore trust_n_pay_score { get; set; }
        public string levenshtein_score { get; set; }
    }

    public class Customer
    {
        public string customer_number { get; set; }
        public string customer_id { get; set; }
        public string customer_type { get; set; }
        public string customer_email { get; set; }
        public string contact_id { get; set; }
        public string contact_email { get; set; }
    }

    public class BillingAddress
    {
        public string address_key { get; set; }
        public string address_format { get; set; }
        public string address_type { get; set; }
        public string company { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string street4 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country_region_code { get; set; }
        public string country_code { get; set; }
        public string tax_number { get; set; }
        public string has_valid_tax_number { get; set; }
    }

    public class ShippingAddress
    {
        public string address_key { get; set; }
        public string address_format { get; set; }
        public string address_type { get; set; }
        public string company { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string street4 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country_region_code { get; set; }
        public string country_code { get; set; }
        public string tax_number { get; set; }
    }

    public class OrderHeader
    {
        public string order_id { get; set; }
        public string order_number { get; set; }
        public string order_datetime { get; set; }
        public string order_timezone { get; set; }
        public string order_currency { get; set; }
        public string order_reference_id { get; set; }
        public string order_reference_order_number { get; set; }
        public string order_reference_reason { get; set; }
        public string offer_id { get; set; }
        public string offer_reference_number { get; set; }
        public Origin origin { get; set; }
        public Creator creator { get; set; }
        public List<Discount> discounts { get; set; }
        public List<Payment> payments { get; set; }
        public Totals totals { get; set; }
        public RiskCheck risk_check { get; set; }
        public Customer customer { get; set; }
        public BillingAddress billing_address { get; set; }
        public List<ShippingAddress> shipping_addresses { get; set; }
    }

    public class PartIdentificationProperties
    {
        public string car_type_number { get; set; }
        public string pr_number { get; set; }
        public string oe_number { get; set; }
        public string car_selection_type { get; set; }
        public string hsn { get; set; }
        public string tsn { get; set; }
    }

    public class ItemNumbers
    {
        public List<string> ean { get; set; }
        public string data_supplier_number { get; set; }
        public string manufacturer_product_number { get; set; }
    }

    public class Offer
    {
        public string name { get; set; }
        public string info_text { get; set; }
    }

    public class Order
    {
        public string name { get; set; }
        public string info_text { get; set; }
    }

    public class Invoice
    {
        public string name { get; set; }
        public string info_text { get; set; }
    }

    public class ItemInformation
    {
        public string image_url { get; set; }
        public string thumbnail_url { get; set; }
        public string brand { get; set; }
        public string is_bulky_good { get; set; }
        public string is_risky_good { get; set; }
        public string is_hazardous_good { get; set; }
        public object legal_notices { get; set; }
        public string pricehammer { get; set; }
        public Offer offer { get; set; }
        public Order order { get; set; }
        public Invoice invoice { get; set; }
    }

    public class ItemRule
    {
        public string identifier { get; set; }
        public List<object> related_skus { get; set; }
    }

    public class Creator2
    {
        public string type { get; set; }
        public string creator_id { get; set; }
        public string creator_name { get; set; }
    }

    public class Tax
    {
        public string type { get; set; }
        public string rate { get; set; }
        public double value { get; set; }
    }

    public class SumValues
    {
        public double sales_value_gross { get; set; }
        public double sales_value_net { get; set; }
        public double goods_value_gross { get; set; }
        public double goods_value_net { get; set; }
        public double deposit_gross { get; set; }
        public double deposit_net { get; set; }
        public double bulky_goods_gross { get; set; }
        public double bulky_goods_net { get; set; }
        public double risky_goods_gross { get; set; }
        public double risky_goods_net { get; set; }
        public double discount_gross { get; set; }
        public double discount_net { get; set; }
        public double total_discounted_gross { get; set; }
        public double total_discounted_net { get; set; }
    }

    public class UnitValues
    {
        public double sales_value_gross { get; set; }
        public double sales_value_net { get; set; }
        public double goods_value_gross { get; set; }
        public double goods_value_net { get; set; }
        public double deposit_gross { get; set; }
        public double deposit_net { get; set; }
        public double bulky_goods_gross { get; set; }
        public double bulky_goods_net { get; set; }
        public double risky_goods_gross { get; set; }
        public double risky_goods_net { get; set; }
        public double rrp_gross { get; set; }
        public double rrp_net { get; set; }
        public double undiscounted_sales_value_gross { get; set; }
        public double undiscounted_sales_value_net { get; set; }
    }

    public class Item
    {
        public double sales_value_gross { get; set; }
        public double sales_value_net { get; set; }
        public double goods_value_gross { get; set; }
        public double goods_value_net { get; set; }
        public double deposit_gross { get; set; }
        public double deposit_net { get; set; }
        public double bulky_goods_gross { get; set; }
        public double bulky_goods_net { get; set; }
        public double risky_goods_gross { get; set; }
        public double risky_goods_net { get; set; }
        public double discount_gross { get; set; }
        public double discount_net { get; set; }
    }

    public class OrderItem
    {
        public string position { get; set; }
        public string row_key { get; set; }
        public string sku { get; set; }
        public double quantity { get; set; }
        public string quantity_unit_type { get; set; }
        public PartIdentificationProperties part_identification_properties { get; set; }
        public ItemNumbers item_numbers { get; set; }
        public ItemInformation item_information { get; set; }
        public List<ItemRule> item_rules { get; set; }
        public Creator2 creator { get; set; }
        public Tax tax { get; set; }
        public SumValues sum_values { get; set; }
        public UnitValues unit_values { get; set; }
        public List<Item> items { get; set; }
    }

    public class SelfPickup
    {
        public string store_location_code { get; set; }
        public string store_location_name { get; set; }
    }

    public class LogisticalItem
    {
        public string row_key { get; set; }
        public string quantity { get; set; }
    }

    public class LogisticalUnit
    {
        public string shipping_address_key { get; set; }
        public string contact_salutation { get; set; }
        public string contact_first_name { get; set; }
        public string contact_last_name { get; set; }
        public string contact_phone_number { get; set; }
        public string contact_email { get; set; }
        public string customer_comment { get; set; }
        public SelfPickup self_pickup { get; set; }
        public string shipping_advice { get; set; }
        public string shipping_provider { get; set; }
        public string shipping_type { get; set; }
        public string expected_delivery_date { get; set; }
        public string expected_delivery_message { get; set; }
        public string tracking_number { get; set; }
        public string tracking_link { get; set; }
        public List<LogisticalItem> logistical_items { get; set; }
    }

    public class EcpSalesOrderDto
    {
        public string version { get; set; }
        public OrderHeader order_header { get; set; }
        public List<OrderItem> order_rows { get; set; }
        //public List<LogisticalUnit> logistical_units { get; set; }
    }
}
