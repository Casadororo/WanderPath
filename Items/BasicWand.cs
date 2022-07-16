using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WanderPath.Items
{
    public class BasicWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("This is a basic wand.");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Magic;

            Item.shootSpeed = 17f;
            Item.shoot = 731;
            Item.mana = 4;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int num11 = 3;

            for (int m = 0; m < num11; m++)
            {
                Vector2 pointPoisition = new Vector2(player.position.X + (float)Item.width * 0.5f + (float)(Main.rand.Next(201) * -player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                pointPoisition.X = (pointPoisition.X * 10f + player.Center.X) / 11f + (float)Main.rand.Next(-100, 101);
                pointPoisition.Y -= 150 * m;
                float num2 = (float)Main.mouseX + Main.screenPosition.X - pointPoisition.X;
                float num3 = (float)Main.mouseY + Main.screenPosition.Y - pointPoisition.Y;
                if (num3 < 0f)
                    num3 *= -1f;

                if (num3 < 20f)
                    num3 = 20f;

                float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                num4 = Item.shootSpeed / num4;
                num2 *= num4;
                num3 *= num4;
                float speedX = num2 + (float)Main.rand.Next(-40, 41) * 0.03f;
                float speedY = num3 + (float)Main.rand.Next(-40, 41) * 0.03f;
                speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                pointPoisition.X += Main.rand.Next(-50, 51);
                int num13 = Projectile.NewProjectile(source, pointPoisition.X, pointPoisition.Y, speedX, speedY, Item.shoot, Item.damage, Item.knockBack, Main.myPlayer);
                //Main.projectile[num13].noDropItem = true;
            }
            
			return false;
        }
    }
}