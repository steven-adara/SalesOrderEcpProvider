using System;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class SalesOrderPaymentDto
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public SalesOrderPaymentProviderDataDto ProviderData { get; set; }
    }

    public class SalesOrderPaymentProviderDataDto
    {
        public string TransactionId { get; set; }
        public string PseudoCardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardBrand { get; set; }
        public string OrderDescription { get; set; }
        public string PaymentId { get; set; }
        public string Status { get; set; }
        public string PaymentProviderOrderDescription { get; set; }
        public string PaymentProviderCode { get; set; }
        public string SenderHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankIdentifierCode { get; set; }
        public string CountryCode { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}