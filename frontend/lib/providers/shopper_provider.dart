
import '../models/shopper.dart';
import 'base_provider.dart';

class ShopperProvider<T> extends BaseProvider<Shopper> { 

  ShopperProvider() : super("Shopper"); 

   @override
  Shopper fromJson(data) {
    return Shopper.fromJson(data);
  }
  
  @override
  Shopper mapFromJson(Map<String, dynamic> json) {
    // TODO: implement mapFromJson
    return Shopper.fromJson(json);
  }
}
