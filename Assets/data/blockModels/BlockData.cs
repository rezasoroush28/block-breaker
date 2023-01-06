using data.level_handler;
using UnityEngine;
using UnityEngine.Serialization;

namespace data.blockModels
{
    public class BlockData : MonoBehaviour
    {
        [FormerlySerializedAs("thisPrefabData")] public BlockData thisBlockData;
        // Start is called before the first frame update
        public BlockPresenter presenterForThisBlock;
        public int point;
        public LevelModel.BlockCategories blockCat;
        
    }
}