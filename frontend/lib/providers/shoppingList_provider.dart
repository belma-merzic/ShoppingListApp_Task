
import '../models/shoppingList.dart';
import 'base_provider.dart';

class ShoppingListProvider<T> extends BaseProvider<ShoppingList> { 

  ShoppingListProvider() : super("ShoppingList"); 

   @override
  ShoppingList fromJson(data) {
    return ShoppingList.fromJson(data);
  }
  
  @override
  ShoppingList mapFromJson(Map<String, dynamic> json) {
    // TODO: implement mapFromJson
    return ShoppingList.fromJson(json);
  }
}
