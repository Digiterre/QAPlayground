Feature: Credit check

Background:
* url baseUrl

Scenario: Run and own a DI credit check exception scenario

* def scenario =
"""
{
	"scenarioId": "${scenario}"
}
"""

* replace scenario
    | token       | value           |
    | ${scenario} | "outright DI"   |


Given path '/simulator/runscenario'
* header Content-Type = contentType
And request scenario
When method post
Then status 200
And match $ == {responseMessages:'#notnull'}
And match $..type contains "#notnull"
And match $..checkId contains "#notnull"
And match $..quoteRequestId contains "#notnull"
And def quoteId = $..quoteRequestId

* def own =
"""
{"checkId": '<quoteRequestId>', "revoke": "null"}
"""

Given path '/creditcheck/owner'
* header Content-Type = contentType
* header Authorization = call read('basic-auth.js')
And replace own.quoteRequestId = quoteId[0]
And request own
When method post
Then status 200





