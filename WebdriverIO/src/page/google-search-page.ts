class GoogleSearchPage {
    public open() {
        //@ts-ignore
      browser.url('https://google.com')
    }
  
    public search(query: string) {
        //@ts-ignore
      browser.waitForVisible('input[name=q]')
      //@ts-ignore
      browser.setValue('input[name=q]', query)
    }
  
    public getAllLinksText() {
        //@ts-ignore
      browser.waitForVisible('h3 > a')
      //@ts-ignore
      return browser.getText('h3 > a')
    }
  }
  
  const googleSearchPage = new GoogleSearchPage()
  export default googleSearchPage