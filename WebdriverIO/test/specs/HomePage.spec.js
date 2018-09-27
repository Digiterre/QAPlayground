import HomePage from '../pageobjects/HomePage';
import assert from 'assert';



describe('Navigate to HomePage', function(){
    
    it('should allow user to go to this page', function(){
            HomePage.Open();
            console.log(HomePage.getPageTitle());
            expect(HomePage.getPageTitle().toContain('Amazon.co.uk'));
    });
});