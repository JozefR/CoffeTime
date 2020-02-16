#### Previous: [Home &laquo;](../Medium.md)

# IP Validation

[Codewars](https://www.codewars.com/kata/ip-validation)

Write an algorithm that will identify valid IPv4 addresses in dot-decimal format. 
IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.

Input to the function is guaranteed to be a single string.

Examples
Valid inputs:
    
    1.2.3.4
    123.45.67.89
    
Invalid inputs:

    1.2.3
    1.2.3.4.5
    123.456.78.90
    123.045.067.089
    
Note that leading zeros (e.g. 01.02.03.04) are considered invalid.

## Solutions

``` cs  
public static bool is_valid_IP(string ipAddress)
{
    if (Regex.IsMatch(ipAddress, @"^(?:(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])(\.(?!$)|$)){4}$"))
        return true;

    return false;
}

public static bool is_valid_IP2(string ipAddress)
{
    IPAddress ip;
    bool validIp = IPAddress.TryParse(ipAddress, out ip);
    return validIp && ip.ToString() == ipAddress;
}

public static bool is_valid_IP3(string IpAddress)
{
    var octet = "([1-9][0-9]{0,2})";
    var reg = $@"{octet}\.{octet}\.{octet}\.{octet}";
    return new Regex(reg).IsMatch(IpAddress);
}
```

#### Previous: [Home &laquo;](../Medium.md)
