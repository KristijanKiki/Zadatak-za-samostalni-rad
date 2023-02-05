Feature: YoutubeSearchFeature

A short summary of the feature

@scopedBinding
Scenario: Youtube should search for the given keyword and should navigate to search results page
	Given Given I have navigated youtube website 
	And I have entered Selenium as search keywords
	When I press the search button
	Then I should be navigate to search results page