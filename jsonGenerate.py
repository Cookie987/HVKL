import os
import json
import hashlib

# 获取文件的 SHA-256 哈希值
def get_file_hash(file_path):
    sha256 = hashlib.sha256()
    with open(file_path, "rb") as f:
        while chunk := f.read(8192):
            sha256.update(chunk)
    return sha256.hexdigest()

# 生成 JSON 文件
def generate_json(directory, output_file, base_url=""):
    file_list = []

    for root, _, files in os.walk(directory):
        for file in files:
            file_path = os.path.join(root, file)
            file_hash = get_file_hash(file_path)

            # 计算相对路径（保持目录结构）
            relative_path = os.path.relpath(file_path, directory)

            # 构造文件信息
            file_info = {
                "file": relative_path.replace("\\", "/"),  # 统一用 `/` 作为路径分隔符
                "hash": file_hash,
                "url": f"{base_url}/{relative_path.replace('\\', '/')}" if base_url else ""
            }
            file_list.append(file_info)

    # 保存到 JSON 文件
    with open(output_file, "w", encoding="utf-8") as json_file:
        json.dump(file_list, json_file, indent=4, ensure_ascii=False)

    print(f"JSON 文件已生成: {output_file}")

# 用户输入
if __name__ == "__main__":
    game_directory = input("请输入游戏文件所在目录: ").strip()
    output_json = input("请输入要保存的 JSON 文件名 (默认: game_files.json): ").strip() or "game_files.json"
    base_url = input("请输入下载文件的基础 URL（可选）: ").strip()

    if not os.path.isdir(game_directory):
        print("错误: 目录不存在！")
    else:
        generate_json(game_directory, output_json, base_url)
