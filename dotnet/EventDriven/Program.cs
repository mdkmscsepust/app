var orderService = new OrderService();
var notificationService = new NotificationService();
var logService = new LogService();
var userService = new UserRegisteredService();
orderService.OrderPlaced += notificationService.OnOrderPlaced;
userService.UserRegistered += notificationService.OnUserRegistered;
userService.UserRegistered += logService.RegisteredUser;
orderService.PlaceOrder(1);
userService.RegisteredUser("masumcsepust", "masumcsepust@gmail.com");