## Sales Order ECP Provider 

The sales order ECP provider is an anti corruption layer for importing sales orders from ECP into the sales order domain. As such it receives ecp JSON orders through its API and converts and sends them onward into the sales order domain.

## Environment Variables
```
SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_URL
```

## Health and Monitoring endpoints
```
<host>:<port>
/hc
/metrics
```

## API Documentation
The API is documented using swagger. Docs can be found at
```
<host>:<port>
/swagger
``` 
 
## Monitoring and Metrics

No custom metrics yet.