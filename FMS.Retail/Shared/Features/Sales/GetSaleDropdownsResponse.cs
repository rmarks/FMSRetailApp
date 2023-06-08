namespace FMS.Retail.Shared.Features.Sales;

public record GetSaleDropdownsResponse(IEnumerable<PaymentTypeModel> PaymentTypes, IEnumerable<CustomerTypeModel> CustomerTypes);
