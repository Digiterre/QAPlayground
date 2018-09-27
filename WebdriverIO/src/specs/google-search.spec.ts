import { expect } from 'chai'
import googleSearchPage from '../page/google-search-page'

//@ts-ignore
describe('Google search feature', () => {
    

  //sometest
    //@ts-ignore
  it('Search for WebdriverIO', () => {
    googleSearchPage.open()
    googleSearchPage.search('WebdriverIO')
    expect(googleSearchPage.getAllLinksText())
      .includes('WebdriverIO - Selenium 2.0 javascript bindings for nodejs',
      'Failed to search WebdriverIO')
  })
})