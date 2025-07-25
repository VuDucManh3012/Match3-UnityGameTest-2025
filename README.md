# Đánh giá Thiết kế và Tổ chức Dự án

# Ưu điểm
- Thiết kế có tổ chức, dễ dàng mở rộng, sửa đổi.
- Đặt tên đúng định dạng, hợp lý, dễ đọc.
- Sắp xếp folder gọn gàng, rõ ràng.

# Nhược điểm
- Nhiều script còn dài, chưa được tách nhỏ rõ ràng theo chức năng.
- Cần cân nhắc trong việc sử dụng getComponent và FindObjectByType trong các hàm Awake().
- Có nhiều gameObject được tạo bằng new GameObject + AddComponent, nên chuyển thành các prefab để dễ điều khiển, debug hơn.
- Dùng các Resources.Load không phù hợp cho các dự án lớn.
- Luồng khởi tạo của các object còn đang tự khởi tạo ở Awake, Start, nên đưa về 1 luồng chính(ex: GameManager -> InitLevel -> InitCell,...)

# Gợi ý tổ chức lại dự án
- Chia nhỏ hơn các script dài.
- Có thể tạo thêm các script hỗ trợ Editor để tăng hiệu suất làm việc.
- Nếu scale dự án cần phải có thêm config, tool editor cho level, không để random level như hiện tại.
