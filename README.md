# 7SegMatrixTool

7セグメントマトリクス表示器用のデータ作成ツール

## 何ができるの

以下の機能があります。
* パラメータ調整
  * ビットマップ画像(640x480)を7セグ画像に変換できます。
  * 変換時の閾値を0-100の範囲で調整できます。

* 連番画像変換
  * プレフィックス付きの連番ビットマップ画像を7セグ画像に変換できます(最大10000枚)。
  * 同時に7セグメントマトリクス専用形式を作成できます。

* 7セグメントマトリクス専用形式テスト再生
  * 7セグメントマトリクス専用形式ファイルを指定したFPSでテスト再生できます。
  * 音声ファイルを指定すると上記と同時に音声も再生できます。

## どうやって使うの

Visual Studio 2013 以降でビルドしてください。<br>
(NuGetでOpenCvSharp2が追加されます)

実行ファイル単体が欲しい場合はビルド後に<br>
7SegMatrixTool/bin/Debug/ を切り取ってください。

## スクリーンショット

### 起動時の画面

<img src="https://github.com/extsui/7SegMatrixTool/blob/images/10-Start.png" width="600" />

### 連番画像変換の確認

<img src="https://github.com/extsui/7SegMatrixTool/blob/images/20-ConfirmConvert.png" width="600" />

### 連番画像変換中

<img src="https://github.com/extsui/7SegMatrixTool/blob/images/25-Convert.png" width="600" />

### テスト再生

<img src="https://github.com/extsui/7SegMatrixTool/blob/images/30-Play.png" width="600" />

## TODO

* [ ] 赤色対応(テスト再生時に処理時間が間に合わない)
* [ ] セグメント毎のフルカラー対応
* [ ] 7セグメントマトリクスの個数の調整可能化
* [ ] 入力画像のサイズの変更可能化
* [ ] 7セグメントマトリクス内の7セグ間の調整可能化(XY方向)

## ライセンス

MIT
