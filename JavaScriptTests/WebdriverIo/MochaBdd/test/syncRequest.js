// //A technique that allows you to create users or add specific data to your SUT.
// var request = require("sync-request");

// describe.skip('Sync Request', function(){
//     beforeEach('', function(){
//         browser.url("./");
//         var res = request('POST', 'https://example.com/create-user', {
//             json:{
//                 'name': 'Mr Mayhem',
//                 'username': 'MrMayhem',
//                 'email': 'mrMayhem@example.com',
//                 'website':'mayhemLand.org'
//             }
//         });
//         var user = JSON.parse(res.getBody('utf8'));
//     });

//     it.skip('A sync request', function(){
//         var res = request('GET', 'http://jsonplaceholder.typicode.com/posts/1/comments');
//         var comments = TSON.parse(res.getBody().toString('utf8'));
//     });
// });