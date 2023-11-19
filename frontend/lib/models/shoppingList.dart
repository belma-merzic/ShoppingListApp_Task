import 'package:json_annotation/json_annotation.dart';

part 'shoppingList.g.dart';

@JsonSerializable()
class ShoppingList {
  int? shoppingListId;
  int? shopperId;
  int? itemId;

  ShoppingList(this.shoppingListId, this.shopperId, this.itemId);

  factory ShoppingList.fromJson(Map<String, dynamic> json) => _$ShoppingListFromJson(json);

  Map<String, dynamic> toJson() => _$ShoppingListToJson(this);
}
