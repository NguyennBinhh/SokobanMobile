# 🎮 Sokoban2D

🚀 Sokoban Puzzle Game là một dự án game giải đố 2D cổ điển được phát triển bằng Unity, lấy cảm hứng từ trò chơi Sokoban huyền thoại xuất hiện từ những năm 1980.
Trong game, người chơi vào vai một nhân vật di chuyển trong mê cung gồm các khối tường, hộp, và các điểm đánh dấu (checkpoint). Nhiệm vụ chính là đẩy tất cả các hộp vào đúng vị trí checkpoint với số bước đi ít nhất có thể — không có cơ chế kéo, chỉ được đẩy và không thể đi xuyên tường hoặc đẩy nhiều hộp cùng lúc.<br>

🚀 Game tập trung vào yếu tố logic, tính toán đường đi hiệu quả và sử dụng chiến lược để giải từng màn chơi. Mỗi cấp độ đều mang tính thử thách riêng: từ dễ nắm bắt ở cấp độ đầu đến các câu đố phức tạp đòi hỏi người chơi phải thử nghiệm, sai và hoàn tác nhiều lần trước khi tìm ra giải pháp đúng.<br>

---
## 📖 Mô Tả

- **Thể loại**: 2D, puzzle, Mobile
- **Công cụ**: Unity (phiên bản 2022.3.58f1), Visual Studio 2022, Adobe Photoshop  
- **Mục tiêu**: Hoàn thành trò chơi đầy đủ các tính năng chính như giao diện trang chủ, chọn màn chơi, tải và lưu dữ liệu theo từng màn, reload, pause, ... Tối ưu hệ thống gameplay mượt mà, mâng lại trải nghiệm tốt cho người chơi. Phục vụ cho việc làm dự án cá nhân để giới thiệu kĩ năng của bản thân cũng nhữ các định hướng khác trong tương lai. 

---
## 🔧 Tính năng:

- ✔️ Hệ thống điều khiển đơn giản, phù hợp với nhiều đối tượng.<br>
  
- ✔️ Undo nhiều bước (cả vị trí người chơi và hộp) để hỗ trợ trải nghiệm thử–sai hiệu quả.<br>

- ✔️ Thiết kế modular và mở rộng dễ dàng thêm nhiều màn chơi mới chỉ bằng cách cập nhật file JSON dữ liệu màn chơi.<br>

- ✔️ Đổi màu hộp theo trạng thái (đúng/không đúng vị trí), giúp phản hồi trực quan hơn cho người chơi.<br>

- ✔️ Hệ thống âm thanh tách rời bằng ScriptableObject, dễ mở rộng và kiểm soát cho từng hành động trong game.<br>

- ✔️ Đồng bộ hóa dữ liệu giữa lần chơi đầu tiên và sau khi build game, đảm bảo file JSON được tự động sao chép từ thư mục StreamingAssets sang persistentDataPath.<br>

- ✔️ Thiết kế mã nguồn theo nguyên tắc solid


---


## 📸 Demo

<p align="left">
  <img src="demo/1.gif" width="195">
  <img src="demo/2.gif" width="195">
  <img src="demo/3.gif" width="195">
  <img src="demo/4.gif" width="195">
  <img src="demo/5.gif" width="195">
   <img src="demo/6.gif" width="195">
  <img src="demo/7.gif" width="195">
  <img src="demo/8.gif" width="195">
  <img src="demo/9.gif" width="195">
  <img src="demo/10.gif" width="195">
<img src="demo/11.gif" width="195">
  <img src="demo/12.gif" width="195">
  
  <i>Sample results</i>
</p>

## 🕹️ Yêu Cầu & Cài Đặt (Requirements & Setup)
1, Tải và cài đặt Unity 2022.3.58f1 LTS hoặc cao hơn

2, Clone dự án: git clone https://github.com/NguyennBinhh/SokobanMobile.git

3, Mở dự án qua Unity Hub

4, Nhấn Play để chạy thử trong Editor

📂 Lưu ý: File LevelData.json gốc được copy từ StreamingAssets vào Application.persistentDataPath ở lần chạy đầu tiên nếu chưa có.

## 🛣️ Roadmap
✅ Cơ bản Sokoban hoạt động

✅ Undo đa bước

✅ Hệ thống lưu dữ liệu level của người chơi

✅ Menu chọn level

✅ Hệ thống âm thanh

🟩 Gợi ý đường đi

🟩 Hiệu ứng chuyển cảnh

🟩 Bảng xếp hạng người dùng

## 👥 Credits
Font: Kenney.nl

Âm thanh: FreeSound.org

Icon & Tileset: Kenney Tiles Pack

Code, thiết kế và triển khai bởi Nguyễn Bá Bình(Shuu Game Dev).
