# DeepRacerAnalyzer
This is my own small helper tool to optimize AWS DeepRacer models

## Usage and features

Here is the description of all the features. Also, note that double-clicking on any picture displayed in the tool will export it to the clipboard - a nice way to share your work on Slack :)

### Load track
First, start a project by loading a track, either from Numpy file or from waypoints, and some extra parameters 
- **From Numpy file**
Select a .npy file that corresponds to a track. Official tracks are available on [AWS DeepRacer Workshop repo](https://github.com/aws-samples/aws-deepracer-workshops/tree/master/log-analysis/tracks).
You can also paste a URL in the file selection textbox, the system will download it and store it in your local temp directory

- **From way points and track width**
If you don't have access to complete NPY file (with waypoints + inner and outer borders), you can still extract waypoints (for example, using print() during training) and track width.
This mode recomputes inner and outer borders from waypoints and track width. It may not be the exact same values than what's stored in NPY files but it's accurate enough for our needs

- **Other projects parameters**
  - Path > Curving iteration count : indicates how many iterations will be done to compute (iteratively) the optimal path.
  Default is 1000 - about 1s CPU to compute for most tracks
  - Path > Inner band percentage : indicates the percentage of the track you plan to use. High value : smoother path but higher risk to get off track. Examples
  100% : use the whole track
  50% : use half of the width, centered on the waypoints line
  Default is 80
  - Speed > Min speed : the default speed tentatively applied on the sharpest turns of your path
  Default is 1.7 m/s - quite high, used only for really smooth paths
  - Speed > Forecast : number of lookaheads in speed variations (=> number of steps to prepare braking)
  Default is 5

### Main screen
Once your project is loaded, you can access all the different project tabs
- **Path finder**
Shows the optimal path (blue) that fits inside the "safety inner band" (orange) for the given track (red). Default way points are also displayed for comparison (golden line)
- **Simulation**
Shows the path that need to be followed, with speed markers on a white / green / orange / red gradient.
- **ActionSpace**
Visual representation of the action space based on the optimal path.
As there are generally more than 21 actions, yellow points are the result of a KMeans++ classification
- **Payload injection**
In case you want to use this action space using the modified payload way : this is the prepared payload portion for action space.
Otherwise, just remove all the \\\\\\ and get the Json action space to be used in model_metadata.json file
- **Reward function**
An example of reward function you can use. It basically finds where you are regarding to the optimal path, then computes different portions of the reward (with different weights) on distance, speed delta, direction delta, steering...

### Robomaker Logs
**Note** : do not use this feature to view 10-hour-long training robomaker logs. It works, but it'll create about ten thousand tabs... this tool is more focused on evaluation logs analysis

To use it, just load a robomaker log file : it'll display a new window with one tab per lap.
The drawing convention is the same than the "Simulation" main tab, except it also displays completion and time (in red or green based on lap completion status)

The Log window is not modal : you can open several windows and compare informations

### Speed increase tool
This tool loads a json file, apply scale factors on actionspace speeds and save it as model_metadata.json. If you want to artificially increase speed of an already trained, stable, model, then you can use this tool to increase action speeds - then upload the new json file to S3 in a cloned model, and import this new model.
On _Reinvent 2019_ track, we had a model that performed 6 laps / 7, with a best time of 10.5s.
After applying speedhack, it was 1 lap / 7, but with a best time of 9.5s...
