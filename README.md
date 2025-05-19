# 🎮 Sokoban2D

> Sokoban Puzzle Game là một dự án game giải đố 2D cổ điển được phát triển bằng Unity, lấy cảm hứng từ trò chơi Sokoban huyền thoại xuất hiện từ những năm 1980.
Trong game, người chơi vào vai một nhân vật di chuyển trong mê cung gồm các khối tường, hộp, và các điểm đánh dấu (checkpoint). Nhiệm vụ chính là đẩy tất cả các hộp vào đúng vị trí checkpoint với số bước đi ít nhất có thể — không có cơ chế kéo, chỉ được đẩy và không thể đi xuyên tường hoặc đẩy nhiều hộp cùng lúc.<br>

Game tập trung vào yếu tố logic, tính toán đường đi hiệu quả và sử dụng chiến lược để giải từng màn chơi. Mỗi cấp độ đều mang tính thử thách riêng: từ dễ nắm bắt ở cấp độ đầu đến các câu đố phức tạp đòi hỏi người chơi phải thử nghiệm, sai và hoàn tác nhiều lần trước khi tìm ra giải pháp đúng.<br>

---
## 📖 Mô Tả

- **Thể loại**: (ví dụ: 2D platformer, racing, adventure…)  
- **Engine**: Unity (phiên bản X.Y.Z)  
- **Mục tiêu**: Mô tả ngắn về gameplay, câu chuyện, hoặc trải nghiệm chính mà người chơi sẽ có.  

---
## 📖 Tính năng:

- Undo nhiều bước (cả vị trí người chơi và hộp) để hỗ trợ trải nghiệm thử–sai hiệu quả.<br>

- Thiết kế modular và mở rộng dễ dàng thêm nhiều màn chơi mới chỉ bằng cách cập nhật file JSON dữ liệu màn chơi.<br>

- Đổi màu hộp theo trạng thái (đúng/không đúng vị trí), giúp phản hồi trực quan hơn cho người chơi.<br>

- Hệ thống âm thanh tách rời bằng ScriptableObject, dễ mở rộng và kiểm soát cho từng hành động trong game.<br>

- Đồng bộ hóa dữ liệu giữa lần chơi đầu tiên và sau khi build game, đảm bảo file JSON được tự động sao chép từ thư mục StreamingAssets sang persistentDataPath.<br>

- Thiết kế mã nguồn theo nguyên tắc solid


---

## 🚀 Tính Năng

- ✔️ Danh sách các feature chính (ví dụ: multiple levels, drift mechanics, AI opponents…)  
- ✔️ Hệ thống điều khiển đơn giản, responsive  
- ✔️ Hiệu ứng VFX/SFX sống động  

---

## 📸 Hình Ảnh & GIF

<p align="center">
  <img src="path/to/screenshot1.png" width="300" alt="Screenshot 1"/>
  <img src="path/to/screenshot2.png" width="300" alt="Screenshot 2"/>
</p>

Hoặc GIF minh hoạ gameplay:

```md
![Gameplay Demo](path/to/demo.gif)
