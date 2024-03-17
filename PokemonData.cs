using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonData : MonoBehaviour
{
    //énumération des types 
    private enum PokemonType
    {
        electric,
        steel,
        fire,
        water,
        ground,
        fairy,
        poison,
        grass,
        Bug,
        ice,
        fighting,
        flying,
        normal,
        dragon,
        dark,
        Ghost,
        rock,
        psychic
    }

    //Variable qu'on voit dans l'inspecteur
    [SerializeField] private string PokemonName = "Pikachu";
    [SerializeField] private int BaseLife = 50;
    [SerializeField] private int PokemonAttack = 70;
    [SerializeField] private int PokemonDefense = 50;
    [SerializeField] private float PokemonWeight = 6.0f;
    [SerializeField] private string pokemonType = "Electric";
    [SerializeField] private string[] PokemonWeakness = { "Ground" };
    [SerializeField] private string[] PokemonResistances = { "Electric" };

    //Variables qu'on ne voit pas dans l'inpescteur
    private int currentHealth;
    private int statPoints;

    void Start()
    {
        currentHealth = BaseLife;
        InitStatsPoints();
        Display();
        TakeDamage(20, "Electric");
    }

    //Affiche toutes les informations dans l'inspecteurs
    void Display()
    {
        Debug.Log("Pokemon Name: " + PokemonName);
        Debug.Log("BaseLife: " + BaseLife);
        Debug.Log("PokemonAttack: " + PokemonAttack);
        Debug.Log("PokemonDefense: " + PokemonDefense);
        Debug.Log("PokemonWeight: " + PokemonWeight);
        Debug.Log("Pokemon Type: " + pokemonType);
        Debug.Log("Current Health: " + currentHealth);
        Debug.Log("Stat Points: " + statPoints);
        Debug.Log("PokemonWeakness: " + string.Join(", ", PokemonWeakness));
        Debug.Log("PokemonResistances: " + string.Join(", ", PokemonResistances));
    }

    // vie de base du pokemon
    void InitCurrentLife()
    {
        currentHealth = BaseLife;
    }

    //initialisation des stat du pokemon
    void InitStatsPoints()
    {
        statPoints = BaseLife + PokemonAttack + PokemonDefense;
    }
    //initialisation de l'attaque
    int GetAttackDamage()
    {
        return PokemonAttack;
    }

    //Inflige des dégats en fonction du types du pokemon
    void TakeDamage(int damage, string enemyType)
    {
        if (PokemonWeakness != null && System.Array.Exists(PokemonWeakness, type => type == enemyType))
        {
            damage *= 2; 
        }
        else if (PokemonResistances != null && System.Array.Exists(PokemonResistances, type => type == enemyType))
        {
            damage /= 2; 
        }

        if (damage <= 0) return; 

        currentHealth -= damage;
        Debug.Log("Current Health after attack: " + currentHealth);
        CheckIfPokemonAlive();
    }

    //Vérifier la vie du pokemon
    void CheckIfPokemonAlive()
    {
        if (currentHealth <= 0)
        {
            Debug.Log(PokemonName + " is KO!");
        }
        else
        {
            Debug.Log(PokemonName + " is still alive with " + currentHealth + " HP!");
        }
    }

}

