# Tera Term UI Tool

Tera Term をフォーム入力ベースの GUI で操作するための Windows デスクトップアプリ (WPF / .NET 8) です。
コマンドや TTL マクロを直接書かなくても、SSH/Telnet 接続、マクロ生成、ログ設定、ファイル転送を
ボタン操作で扱えるようにします。

## 前提

- Windows 10 / 11
- [.NET 8 SDK](https://dotnet.microsoft.com/) （ビルドする場合）
- [Tera Term 5](https://teratermproject.github.io/) （`ttermpro.exe` と `ttpmacro.exe`）

## ビルドと実行

```powershell
cd TeraTermUiTool
dotnet build
dotnet run --project TeraTermUiTool
```

初回起動時に `Program Files\teraterm5` / `teraterm` から `ttermpro.exe` と `ttpmacro.exe` を自動検出します。
見つからない場合は「設定」タブで明示的に指定してください。

## 機能

### 1. 接続タブ
- プロファイル（ホスト・ポート・ユーザー・認証方式など）を保存できます。
- `SSH2 / Telnet / Serial` を選択でき、必要なオプションだけを表示します。
- `公開鍵` を選ぶと鍵ファイルピッカーが現れます。
- 「接続」を押すと、入力内容をもとに `ttermpro.exe` を起動します（ログ設定タブの設定があれば自動付与）。
- パスワード保存を有効にすると **DPAPI (CurrentUser)** でローカル暗号化されます。

### 2. マクロ作成タブ
- 代表的な TTL コマンド（`connect / sendln / wait / pause / logopen / disconnect` など）をボタンで追加できます。
- ステップを並べ替え・複製・削除できます。
- 下部のプレビューに生成中のマクロが表示されます。
- 「保存して実行」で `ttpmacro.exe` に渡して実行します。

### 3. ログ設定タブ
- ログファイルのパス・追記モード・タイムスタンプ・バイナリ・ダイアログ抑止を設定します。
- 「適用」を押すと次回以降の接続で `/L=`, `/LA=`, `/LB=`, `/LT=`, `/LD=` が自動で付与されます。

### 4. ファイル転送タブ
- `SCP` または `ZMODEM (送信/受信)` を選び、対象ファイルとリモートパスを指定します。
- 既存セッションに対する転送マクロ（`scpsend / scprecv / zmodemsend / zmodemrecv`）を生成し、保存・実行できます。

### 5. 設定タブ
- `ttermpro.exe` と `ttpmacro.exe` のパスを指定します。
- 「自動検出」で `Program Files\teraterm5` / `teraterm` の標準インストールパスを再検索します。

## データの保存先

| 種類 | 場所 |
| --- | --- |
| 設定 | `%APPDATA%\TeraTermUiTool\settings.json` |
| プロファイル | `%APPDATA%\TeraTermUiTool\profiles.json` |
| 暗号化パスワード | プロファイル JSON 内（DPAPI 暗号化済の Base64） |

## セキュリティ上の注意

`ttermpro.exe /passwd=...` は **コマンドライン引数として** パスワードを渡すため、
同一 PC 上の他プロセスがコマンドラインを参照できる環境では機密が漏れる可能性があります。
業務利用や本番サーバーへの接続では、**公開鍵認証**（このアプリの「公開鍵」モード + `*.ppk` 等）の使用を推奨します。

## ライセンス

このリポジトリのライセンスに準じます。
