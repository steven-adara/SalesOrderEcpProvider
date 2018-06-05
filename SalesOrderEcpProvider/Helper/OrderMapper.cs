using System;
using System.Globalization;
using System.Collections.Generic;
using Kfzteile24.SalesOrderEcpProvider.Types;
using System.Linq;

namespace Kfzteile24.SalesOrderEcpProvider.Helper
{
    public class OrderMapper : IMapper
    {
        //maybe this could also be done with automapper in future using json annotations
        //in source dto model
        public SalesOrderDto MapFomDedicated(EcpSalesOrderDto dedicatedOrder)
        {
            return new SalesOrderDto
            {
                OrderNumber = dedicatedOrder.order_header.order_number,
                OrderDateTime = DateTime.Parse(dedicatedOrder.order_header.order_datetime),
                ShippingType = dedicatedOrder.logistical_units.First().shipping_type,
                OrderOrigin = new SalesOrderOriginDto
                {
                    SalesChannel = dedicatedOrder.order_header.origin.sales_channel,
                    SalesLocation = dedicatedOrder.order_header.origin.locale
                },
                Discounts = MapDiscounts(dedicatedOrder.order_header.discounts),
                Payments = MapPayments(dedicatedOrder.order_header.payments),
                TotalPrices = new SalesOrderTotalPriceDto
                {
                    ShippingStandardGross = dedicatedOrder.order_header.totals.shipping_totals_gross.standard,
                    ShippingExpressGross = dedicatedOrder.order_header.totals.shipping_totals_gross.express,
                    ShippingBulkyGoodsGross = dedicatedOrder.order_header.totals.shipping_totals_gross.bulky_goods,
                    ShippingDangerousGoodsGross = dedicatedOrder.order_header.totals.shipping_totals_gross.dangerous_goods,
                    TotalDiscountGrossPrice = dedicatedOrder.order_header.totals.total_discount_gross,
                    PaymentExpensesGrossPrices = new SalesOrderPaymentExpensesGrossDto
                    {
                        CashOnDelivery = dedicatedOrder.order_header.totals.payment_expenses_gross.cash_on_delivery
                    }
                },
                Customer = new SalesOrderCustomerDto
                {
                    Email = dedicatedOrder.order_header.customer.customer_email
                },
                BillingAddress = new SalesOrderAddressDto
                {
                    FirstName = dedicatedOrder.order_header.billing_address.first_name,
                    LastName = dedicatedOrder.order_header.billing_address.last_name,
                    Street1 = dedicatedOrder.order_header.billing_address.street1,
                    Street2 = dedicatedOrder.order_header.billing_address.street2,
                    Street3 = dedicatedOrder.order_header.billing_address.street3,
                    ZipCode = dedicatedOrder.order_header.billing_address.zip_code,
                    City = dedicatedOrder.order_header.billing_address.city,
                    PhoneNumber = dedicatedOrder.order_header.billing_address.phone_number,
                    CountryCode = dedicatedOrder.order_header.billing_address.country_code,
                    Type = AddressType.Billing
                },
                ShippingAddresses = MapShippingAddresses(dedicatedOrder.order_header.shipping_addresses),
                OrderItems = MapItems(dedicatedOrder.order_rows)
            };
        }

        private List<SalesOrderAddressDto> MapShippingAddresses(List<ShippingAddress> dtoItems)
        {
            var items = new List<SalesOrderAddressDto>();

            dtoItems.ForEach(item => items.Add(new SalesOrderAddressDto
            {
                FirstName = item.first_name,
                LastName = item.last_name,
                Street1 = item.street1,
                Street2 = item.street2,
                Street3 = item.street3,
                ZipCode = item.zip_code,
                City = item.city,
                PhoneNumber = item.phone_number,
                CountryCode = item.country_code,
                Type = AddressType.Shipping
            }));

            return items;
        }

        private List<SalesOrderPaymentDto> MapPayments(List<OrderPayment> dtoItems)
        {
            var items = new List<SalesOrderPaymentDto>();

            dtoItems.ForEach(item =>
            {
                var ppd = item.payment_provider_data;

                items.Add(new SalesOrderPaymentDto
                {
                    Type = item.type,
                    Value = item.value,
                    ProviderData = new SalesOrderPaymentProviderDataDto
                    {
                        AccountNumber = ppd.account_number,
                        BankCode = ppd.bank_code,
                        BankIdentifierCode = ppd.bic,
                        BankName = ppd.bank_name,
                        CardBrand = ppd.card_brand,
                        CardExpiryDate = ppd.card_expiry_date,
                        CountryCode = ppd.country_code,
                        OrderDescription = ppd.order_description,
                        PaymentId = ppd.payment_provider_payment_id,
                        PaymentProviderCode = ppd.payment_provider_code,
                        PaymentProviderOrderDescription = ppd.payment_provider_order_description,
                        PseudoCardNumber = ppd.pseudo_card_number,
                        SenderHolder = ppd.sender_holder,
                        Status = ppd.payment_provider_status,
                        TransactionId = ppd.payment_provider_transaction_id,
                        Request = ppd.request,
                        Response = ppd.response
                    }
                });
            });

            return items;
        }

        private List<SalesOrderDiscountDto> MapDiscounts(List<OrderDiscount> dtoItems)
        {
            var items = new List<SalesOrderDiscountDto>();

            dtoItems.ForEach(item => items.Add(new SalesOrderDiscountDto
            {
                PromotionIdentifier = item.promotion_identifier
            }));

            return items;
        }

        private List<SalesOrderItemDto> MapItems(List<SalesOrderItem> dtoItems)
        {
            var items = new List<SalesOrderItemDto>();

            dtoItems.ForEach(item => items.Add(new SalesOrderItemDto
            {
                StockKeepingUnit = item.sku,
                Quantity = item.quantity,
                CarPartProperties = new SalesOrderPartIdentificationDto
                {
                    CarTypeNumber = item.part_identification_properties.car_type_number,
                    ManufacturerNumber = item.part_identification_properties.hsn,
                    ModelCode = item.part_identification_properties.tsn
                },
                Creator = new SalesOrderItemCreatorDto
                {
                    Name = item.creator.creator_name
                },
                ItemInformation = new SalesOrderItemInformationDto
                {
                    PriceHammer = item.item_information.PriceHammer,
                    Order = new SalesOrderItemInformationOrderDto { Name = item.item_information.order.name }
                },
                ItemNumbers = new SalesOrderItemNumerDto
                {
                    DataSupplierNumber = item.item_numbers.data_supplier_number,
                    ManufacturerProductNumber = item.item_numbers.manufacturer_product_number
                },
                SumValues = new SalesOrderItemSumValueDto
                {
                    SalesGrossPrice = item.sum_values.sales_value_gross
                },
                UnitValues = new SalesOrderItemUnitValueDto
                {
                    SalesGrossPrice = item.unit_values.sales_value_gross
                }
            }));

            return items;
        }
    }
}
