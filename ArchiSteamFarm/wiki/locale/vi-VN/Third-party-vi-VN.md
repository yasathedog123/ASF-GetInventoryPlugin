# Bên thứ ba

Mục này chứa một vài phần mở rộng của bên thứ ba được viết dành riêng (hoặc hầu hết) dành cho việc hoạt động cùng ASF. Chúng bao gồm từ các trình cắm ASF, thông qua các ứng dụng web đơn giản và thư viện nội bộ để tích hợp, đến các bot đầy đủ tính năng cho các nền tảng khác. Nếu bạn muốn thêm thứ gì đó vào danh sách, hãy cho chúng tôi biết trên Discord hoặc trên nhóm Steam của chúng tôi.

Xin lưu ý rằng các chương trình bên dưới **không** được duy trì bởi các nhà phát triển ASF và do đó **chúng tôi không đảm bảo về bất kỳ chương trình nào**, đặc biệt là về bảo mật, an toàn hoặc tuân thủ Điều khoản Dịch vụ Steam. Danh sách này được duy trì chỉ để tham khảo. Bạn phải luôn đảm bảo rằng tiện ích của bên thứ ba mà bạn sắp sử dụng đủ an toàn và hợp pháp đối với bạn, vì bạn đang tự chịu rủi ro khi sử dụng tất cả các tiện ích đó.

---

## Phần mở rộng của ASF

### **[Rudokhvist](https://github.com/Rudokhvist)**

- **[ASF-Achievement-Manager](https://github.com/Rudokhvist/ASF-Achievement-Manager)**, phần bổ trợ dành cho ASF cho phép bạn quản lý thành tựu Steam.
- **[BirthdayPlugin](https://github.com/Rudokhvist/BirthdayPlugin)**, phần bổ trợ dành cho ASF để nhận lời chúc mừng sinh nhật.
- **[BoosterCreator](https://github.com/Rudokhvist/BoosterCreator)**, phần bổ trợ dành cho ASF bổ sung chức năng tạo các gói bổ sung.
- **[Case-Insensitive-ASF](https://github.com/Rudokhvist/Case-Insensitive-ASF)**, phần bổ trợ dành cho ASF để đặt tên bot không phân biệt chữ hoa chữ thường.
- **[Commandless-Redeem](https://github.com/Rudokhvist/Commandless-Redeem)**, phần bổ trợ dành cho ASF để triển khai lại việc kích hoạt mã mà không cần lệnh.
- **[ItemDispenser](https://github.com/Rudokhvist/ItemDispenser)**, phần bổ trợ để ASF tự động chấp nhận yêu cầu trao đổi đối với (các) loại mặt hàng nhất định.
- **[Selective-Loot-and-Transfer-Plugin](https://github.com/Rudokhvist/Selective-Loot-and-Transfer-Plugin)**, phần bổ trợ dành cho ASF cung cấp lệnh `transfer` nâng cao để chuyển các vật phẩm trên Steam.

### **[Vita](https://github.com/ezhevita)**

- **[FriendAccepter](https://github.com/ezhevita/FriendAccepter)**, phần bổ trợ để ASF tự động chấp nhận tất cả lời mời kết bạn.
- **[GameRemover](https://github.com/ezhevita/GameRemover)**, phần bổ trợ dành cho ASF triển khai lệnh xoá giấy phép Steam đối với các phiên bản bot đã chọn.
- **[GetEmail](https://github.com/ezhevita/GetEmail)**, phần bổ trợ dành cho ASF triển khai lệnh tìm nạp địa chỉ thư điện tử của các phiên bản bot nhất định trực tiếp từ Steam.
- **[ResetAPIKey](https://github.com/ezhevita/ResetAPIKey)**, phần bổ trợ dành cho ASF triển khai lệnh đặt lại mã API cho các phiên bản bot đã chọn.
- **[SteamKitProxyInjection](https://github.com/ezhevita/SteamKitProxyInjection)**, phần bổ trợ dành cho ASF cho phép các kết nối WebSocket dùng proxy.

### Khác

- **[ASFEnhance](https://github.com/chr233/ASFEnhance)**, phần bổ trợ cho ASF nâng cao nó với nhiều tính năng mới, đặc biệt là các lệnh.

---

## Tích hợp

- **[ASFBot](https://github.com/dmcallejo/ASFBot)**, bot telegram được viết bằng python có tích hợp ASF.
- **[ASF STM userscript](https://greasyfork.org/vi/scripts/404754-asf-stm)**, dành cho những người muốn gửi đề nghị giao dịch tự động tới bot trên **[danh sách ASF STM](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/ItemsMatcherPlugin-vi-VN#publiclisting)** của chúng tôi thông qua trình duyệt web mà không sử dụng tính năng `MatchActively` do ASF cung cấp.
- **[telegram-asf](https://github.com/deluxghost/telegram-asf)**, một bot telegram (tối giản) khác được viết bằng python có tích hợp ASF.

---

## Thư viện

- **[ASF-IPC](https://github.com/deluxghost/ASF_IPC)**, thư viện python để tích hợp thêm với giao diện IPC của ASF.

---

## Đóng gói

- **[Kho AUR #1](https://aur.archlinux.org/packages/asf)**, cho phép bạn dễ dàng cài đặt ASF trên arch linux.
- **[Kho AUR #2](https://aur.archlinux.org/packages/archisteamfarm-bin)**, cho phép bạn dễ dàng cài đặt ASF trên arch linux.
- **[Homebrew](https://formulae.brew.sh/formula/archi-steam-farm)**, cho phép bạn dễ dàng cài đặt ASF trên macOS.
- **[Nix](https://search.nixos.org/packages?channel=unstable&show=ArchiSteamFarm&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, cho phép bạn dễ dàng cài đặt ASF trên các bản phân phối với Nix.
- **[NixOS](https://search.nixos.org/options?channel=unstable&from=0&size=50&sort=relevance&type=packages&query=ArchiSteamFarm)**, cho phép bạn định cấu hình và cài đặt ASF với NixOS.

---

## Công cụ

- **[Trình trích mã](https://ske.xpixv.com)**, cho phép bạn sao-dán mã ở nhiều định dạng khác nhau và tạo lệnh `redeem` cho ASF. Kiểm tra **[kho GitHub](https://github.com/PixvIO/SKE)** để biết thêm chi tiết.
- **[Trình biên tập Cấu hình ASF Hàng loạt](https://github.com/genesix-eu/ASF_MCE)**, cho phép quản lý nhiều cấu hình ASF dễ dàng hơn.

---

## Bạn muốn tìm thêm?

Chúng tôi đề xuất chủ đề **[ArchiSteamFarm](https://github.com/topics/archisteamfarm)** trên GitHub cho tất cả các dự án tích hợp với ASF.