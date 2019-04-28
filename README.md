# Test project description
This test project was developed accroding to requiements and allows users to buy items. <br/>
There are 4 endpoints were developed. So, user can do next (see detailed examples in 'API calls' section):

1. **Register.**
User can perform registration to buy some item in the future.
User should provide email, password and confirmPassword to complete registration.

2. **Login.**
Registred user can ask system to provide a token. Using this token user is able to buy some item.
User should provide login and password. As result, user will get token.

3. **Get all items.**
Any user is able to get list of all items. 

4. **Buy item.**
Authorized user (user, that provided valid token) can buy an item.
User should provide token and itemId that should be bought.

#### Constraints:
- User is not able to buy item, that is absent in the database.
- User is not able to buy out of stock item (item with Quantity = 0).

#### Technologies
- ASP.NET WEB API 2
- SQL SERVER
- Entity Framework

## Class structure

#### Items

This class created to work with items.

Column		DataType	Comment
ItemId		int
Name		string
Description	string
Price		decimal		According to the requirements, int should be used for price, but, much more better store exactly decimal type. This type allows to store fractional values and SQL Server works with decimal fractional values pretty good.
Quantity	int			Count of items, that available to buy.

#### OrderHeader

OrderHeader - class, that store base information about order. This class has one-to-many relationship with OrderItem class.

Column			DataType	Comment
OrderHeaderId	int
OrderDate		DateTime
IdentityUserId	string		Used to store information about user, that created an order.
OrderStatus		enum		Could be used to separate different phases for order. Available values - Placed, Verified, Devlivered. Also, after status will be changed, Available Quantity for items should be descreased

#### OrderItem

OrderItem - class, that store information about added to order item

Column			DataType	Comment
OrderItemId		int
OrderHeaderId	int
ItemId			int
Price			decimal		We should duplicate this field. In case of item price will be changed, no one orderItem price will not be changed.
Count			int


## API calls:


### Auth

- Register
	- Request url: /api/Account/Register
	- Request type: POST
	- Body			
		- UserName:test@test.test
		- Password:asdfqwer1!A
		- ConfirmPassword:asdfqwer1!A

- Login
	- Request url		/token
	- Request type	POST
	- Body			
		- grant_type:password
		- username:test@test.test
		- password:asdfqwer1!A


### Data

- Get all items 
	- Request url: /api/Items
	- Request type: GET

Response data:
```
[
    {
        "itemId": 2,
        "name": "Test Product # 1",
        "description": "Description for Test Product # 1",
        "price": 20.95,
        "quantity": 100
    },
    {
        "itemId": 3,
        "name": "Test Product # 2 (out of stock)",
        "description": "Description for Test Product # 2 (out of stock)",
        "price": 20.15,
        "quantity": 0
    }
]
```


- OrderItem 
	- Request url: /api/Order?itemId=1
	- Request type: POST
	- Request header	
		- Authorization: Bearer {token}

Response data:
```
{
    "isSuccess": true,
    "message": "Order with id '5' was successfully placed",
    "data": {
        "orderHeaderId": 5,
        "orderDate": "2019-04-28T18:41:06.5389461+03:00",
        "orderStatus": 0,
        "identityUserId": "cf666231-a086-4c0c-8b4a-894b82b52236",
        "orderItems": [
            {
                "orderItemId": 5,
                "orderHeaderId": 5,
                "itemId": 2,
                "item": null,
                "price": 20.95,
                "count": 1
            }
        ]
    }
}
```


## Testing

There are two main test classes created.
Only business services are covered by unit tests.

- **ItemServiceUnitTest.** This class is created to check Business logic of ItemService.

- **OrderServiceUnitTest.** This class is created to check Business logic of OrderService. It checks:
	- Is user able to buy item, that is absent in the database
	- Is user able to buy item, that is out of stock
	- Is user able to buy in stock valid item


## Questions and Answers

**Q:** How do we know if a user is authenticated? <br />
**A:** Token-based authentication used in this solution. It means, that user should provide credentials to get a token. This token should be used to requests, that requires authorization.

**Q:** Is it always possible to buy an item?<br />
**A:** No, in this solution, user isn't able to buy an 'out of stock' item (item with stock count = 0)

**Q:** A quick explanation of: choice of data format. Include one example of a request and response. <br />
**A:** Please, read 'API calls' and 'Class structure' sections.

**Q:** What authentication mechanism was chosen, and why?<br />
**A:** Token-based mechanism was chosen because this method could use any client - another server, mobile application or front-end application.
