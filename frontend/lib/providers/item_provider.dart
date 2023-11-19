
import '../models/item.dart';
import 'base_provider.dart';

class ItemProvider<T> extends BaseProvider<Item> { 

  ItemProvider() : super("Item"); 

   @override
  Item fromJson(data) {
    return Item.fromJson(data);
  }
  
  @override
  Item mapFromJson(Map<String, dynamic> json) {
    // TODO: implement mapFromJson
    return Item.fromJson(json);
  }
}
