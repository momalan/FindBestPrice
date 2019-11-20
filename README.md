# FindBestPrice
ASP.NET application

Main funcionality of application:
- Comparing different prices with given eventual costs and then choosing the best price for your new product.

Examples:
----------------------------------
Prices: {13,22,35}
Costs:  {0 ,0 ,0 }

Returns: 22

=================================================================
    	
Prices: {13,22,35}
Costs:  {5 ,15,30}

Returns: 13

=================================================================
    	
Prices: {13,22,35}
Costs:  {15,30,40}

Returns: 0

=================================================================
    	
Prices: {10,10,20,20,5}
Costs:  {1 ,5 ,11,15,0}

Returns: 10

=================================================================
    	
Prices: {13,17,14,30,19,17,55,16}
Costs:  {12,1 ,5 ,10,3 ,2 ,40,19}

Returns: 17

-----------------------------------------------------------------

Load **FindBestPrice.sln** to Visual Studio and run.

In case you have such an error like: "Could not find a part of the path … bin\roslyn\csc.exe" do this:

- Delete all the bin and obj folders
- Run this in the Package Manager Console:
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

RUN!


