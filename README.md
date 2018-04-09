# ConversionApp
This Project Comprise of 2 Projects and 2 Test Project

Web Api project name is ConversionAPI and it make use of WebAPI 2.

ConversionAPI uses SimpleInjector as DI container.

CORS are enabled for CoversionAPI.

To make use of CoversionAPI project, please use following steps:
	1. Take latest and build on your machine
	2. Post Build Please create binding for API to host. 
	3. This API project is tested with local hostname and binding as 'local.conversionapi.com'
	4. Add host entry
	5. Conversion API is hosted on address 'http://local.conversionapi.com/api/conversion/ConvertNumtoAlpha'
	
This API is consumed by client with name ConversionApp.

ConversionApp make use of ReactJS.Net as JS framework to make call to API.

To use Client, please make local binding with 'local.conversionapp.com'

Add host entry for same.

User Interface page can be located on address 'http://local.conversionapp.com/DollarConversion/Convert'

Entire code base for React can be found by following physical path '/CoversionApp/CoversionApp/Scripts/Convert.jsx'
  
PS To use this app by simply pressing F5 Button, please run conversionapi proect and then conversionapp project and make changes to url section in file Covert.jsx on section '<ConversionBox url="http://local.conversionapi.com/api/conversion/ConvertNumtoAlpha" />'
