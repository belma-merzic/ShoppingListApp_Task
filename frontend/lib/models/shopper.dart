import 'package:json_annotation/json_annotation.dart';

part 'shopper.g.dart';

@JsonSerializable()
class Shopper {
  int? shopperId;
  String? shopperName;

  Shopper(this.shopperId, this.shopperName);

  factory Shopper.fromJson(Map<String, dynamic> json) => _$ShopperFromJson(json);

  Map<String, dynamic> toJson() => _$ShopperToJson(this);
}
