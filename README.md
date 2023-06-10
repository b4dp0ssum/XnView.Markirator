# XnView.Markirator  
This is simple console application that is designed to integrate [DeepDanbooru] *(image tag estimation system)* and [XnView] *(image viewer)*. You can also use it to assign categories (tags) with [XnView] via JSON files (without using [DeepDanbooru]).

## Commands
*  `evaluate`: Command to calculate the tags for a stack of images (you can specify the path to a folder or to a specific file). The result of the command will be a generated JSON file with tags in the `\EvaluatedTags` directory in the application folder.
	* `--path`: _[optional]_ path to folder or image
	* `--project`: _[optional]_ path to pretrained model DeepDanbooru project
```sh
XnView.Markirator.App evaluate
XnView.Markirator.App evaluate --path "D:\Images\Catalog\image1.jpg" --project "D:\Images\deepdanbooru-v3-20211112-sgd-e28" 
```
You can choose not to specify parameters if their values are prescribed in the application configuration.

* `import`: The command to import categories (tags) into a stack of images in [XnView]. You can use a file created by the `evaluate` command or create one manually.
	* `--path`: _[optional]_ path to JSON with tags info. If no argument is given, all JSON files in the EvaluatedTags folder are processed.
```sh
XnView.Markirator.App import --path "C:\Apps\XnView.Markirator\EvaluatedTags\Tags_2023-04-6_03-56-28.json" 
```

## Import Data Format
The `import` command requires a JSON file with the following data structure:
```json
[
  {
    "FilePath": "D:\\Images\\Catalog\\image1.jpg",
    "Tags": ["tag1", "tag2", "tag3"]
  },
  {
    "FilePath": "D:\\Images\\Catalog\\image2.jpg",
    "Tags": ["tag2", "tag5"]
  }
]
```
_You only need this information if you want to set the tags manually without using DeepDanbooru._

## Installation
1) Download the [DeepDanbooru] repository archive and extract it to your PC
2) Install [DeepDanbooru]
```sh
cd "C:\Apps\Folder_with_extracted_DeepDanbooru"
pip install .[tensorflow]
```
3) Download and extract last [DeepDanbooru Pretrained Model]
4) Download and extract **XnView.Markirator**
5) Setup `appsettings.json` in **XnView.Markirator** folder
	* `DeepDanbooruSettings.ImagePath`: the path to the image or folder for which the tagging will be performed;
	* `DeepDanbooruSettings.ProjectPath`: the path to the folder with the unpacked DeepDanbooru Pretrained Model (from step 3)
	* `XnViewSettings.DbFolder`: path to the folder with the XnView database (XnView -> Settings -> Integration -> Paths -> Folder for catalog)
	* `XnViewSettings.ImagesCatalogPath`: XnView base pictures path (XnView -> Settings -> Catalog -> Base path of your pictures)

[//]: # (Links)
   [DeepDanbooru]: <https://github.com/KichangKim/DeepDanbooru>
   [DeepDanbooru Pretrained Model]: <https://github.com/KichangKim/DeepDanbooru/tags>
   [XnView]: <https://www.xnview.com>  