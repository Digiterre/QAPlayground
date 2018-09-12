Feature: WeatherForecast
	In order to get weather information for my holiday destination
	As a user
	I want to query the open weather api

#Expected Response 200
Scenario Outline: Good Weather Check
	Given I am in the city of <city>
	And I only like to holiday on <day>
	When I look up the weather forecast
	Then I should get the weather forecast with <Httpstatus>
	And the temperature should be warmer than <temperature>
	Examples: 
	| city   | day    | temperature | Httpstatus |
	| Lagos  | Monday | 10          | 200        |
	| Doha   | Monday | 10          | 200        |
	| Mumbai | Monday | 20          | 200        |

##Expected Response 404
Scenario Outline: Good Weather Check for Wrong City
	Given I am in the city of <city>
	And I only like to holiday on <day>
	When I look up the weather forecast
	Then I should get the weather forecast with <Httpstatus>
	Examples: 
	| city | day    | temperature | Httpstatus |
	| A1   | Monday | 10          | 404        |
	| A2   | Monday | 20          | 404        |


#Authentication Error response 401
Scenario Outline: Weather Check Without Authentication
	Given I look up the weather forecast for <city> with bad apiKey
	Then I should get an invalid response from <Httpstatus> the api
	Examples: 
	| city  | Httpstatus |
	| Lagos | 401        |
	| Milan | 401        |


